using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.View.Products
{
    public partial class InsertProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || !UserRepository.isAdmin(Int32.Parse(Session["user"].ToString())))
            {
                Response.Redirect("/View/Home.aspx");
                return;
            }
            if (!IsPostBack) {
                List<ProductType> productTypeList = ProductTypeRepository.getAllProducts().ToList();
                ProductTypeBox.DataSource = productTypeList;
                ProductTypeBox.DataTextField = "Name";
                ProductTypeBox.DataValueField = "ID";
                ProductTypeBox.DataBind();
            }
        }

        protected void insertProduct(object sender, EventArgs e)
        {
            string name = ProductNameBox.Text;
            int price = Int32.Parse(PriceBox.Text);
            int stock = Int32.Parse(StockBox.Text);
            int productType = Int32.Parse(ProductTypeBox.SelectedValue);

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
            else if(productType < 0)
            {
                ErrorMessage.Text = "Product type must be choosen!";
                return;
            }

            try
            {
                ProductRepository.addProduct(productType, name, price, stock);
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