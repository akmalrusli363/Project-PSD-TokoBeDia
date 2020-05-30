using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;
using TokoBeDia.Model;

namespace TokoBeDia.View.Products
{
    public partial class UpdateProduct : System.Web.UI.Page
    {
        private static Product currentProduct = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || !UserRepository.isAdmin(Int32.Parse(Session["user"].ToString())))
            {
                Response.Redirect("/View/Home.aspx");
                return;
            }
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("ViewProduct.aspx");
                return;
            }
            if (!IsPostBack) {
                int productID = Int32.Parse(Request.QueryString["id"]);
                attachProperties(productID);
            }
        }

        private void attachProperties(int productID)
        {
            if (!IsPostBack)
            {
                currentProduct = ProductRepository.getProductByID(productID);
                ProductNameBox.Text = currentProduct.Name;
                PriceBox.Text = currentProduct.Price.ToString();
                StockBox.Text = currentProduct.Stock.ToString();
            }
        }

        protected void updateProduct(object sender, EventArgs e)
        {
            string name = ProductNameBox.Text;
            int price = Int32.Parse(PriceBox.Text);
            int stock = Int32.Parse(StockBox.Text);

            if (name.Length <= 0)
            {
                ErrorMessage.Text = "Name must be filled!";
                return;
            }
            else if (price < 1000 || price % 1000 != 0)
            {
                ErrorMessage.Text = "Price must at least 1000 and multiply of 1000!";
                return;
            }
            else if (stock < 0)
            {
                ErrorMessage.Text = "Stock must at least 1!";
                return;
            }

            try
            {
                ProductRepository.updateProduct(currentProduct.ID, name, price, stock);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ErrorMessage.Text = "Database update on server failure, please try again!";
                return;
            }
            Response.Redirect("ViewProduct.aspx");
        }
    }
}