using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;
using TokoBeDia.Model;

namespace TokoBeDia.View.Products
{
    public partial class InsertProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || !UserController.isAdmin(Int32.Parse(Session["user"].ToString())))
            {
                Response.Redirect("/View/Home.aspx");
                return;
            }
            if (!IsPostBack)
            {
                List<ProductType> productTypeList = ProductTypeController.getAllProductTypes();
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

            string error = ProductController.insertProduct(name, price, stock, productType);

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