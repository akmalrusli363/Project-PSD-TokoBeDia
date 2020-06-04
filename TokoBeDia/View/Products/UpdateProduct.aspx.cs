using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Model;
using TokoBeDia.Controller;

namespace TokoBeDia.View.Products
{
    public partial class UpdateProduct : System.Web.UI.Page
    {
        private static Product currentProduct = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || !UserController.isAdmin(Int32.Parse(Session["user"].ToString())))
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
                currentProduct = ProductController.getProductByID(productID);
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

            string error = ProductController.updateProduct(currentProduct, name, price, stock);

            if (error == "")
            {
                Response.Redirect("ViewProduct.aspx");
            }
            else
            {
                ErrorMessage.Text = error;
            }
        }
    }
}