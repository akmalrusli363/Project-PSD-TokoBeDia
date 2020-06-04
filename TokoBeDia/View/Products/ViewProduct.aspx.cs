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
    public partial class ViewProduct : System.Web.UI.Page
    {
        private static Product currProduct = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductTable.DataSource = ProductController.getAllProducts();
            ProductTable.DataBind();
        }

        protected void insertProduct(object sender, EventArgs e)
        {
            Response.Redirect("InsertProduct.aspx");
        }

        protected void updateProduct(object sender, EventArgs e)
        {
            if (currProduct == null)
            {
                return;
            }

            int currProductID = currProduct.ID;
            Response.Redirect("UpdateProduct.aspx?id=" + currProductID);
            currProduct = null;
        }

        protected void deleteProduct(object sender, EventArgs e)
        {
            if (currProduct == null)
            {
                return;
            }

            string error = ProductController.deleteProduct(currProduct);

            if (error == "")
            {
                currProduct = null;
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                ErrorMessage.Text = error;
            }
        }

        protected void AddToCartButton_Click(object sender, EventArgs e)
        {
            if (currProduct == null)
            {
                return;
            }

            int currProductID = currProduct.ID;
            Response.Redirect("../Carts/AddCart.aspx?id=" + currProductID);
            currProduct = null;
        }


        protected void linkSelect_Click(object sender, EventArgs e)
        {
            int productID = Int32.Parse((sender as LinkButton).CommandArgument);
            currProduct = ProductController.getProductByID(productID);
            ProductType currProductType = ProductTypeController.getProductTypeByID(currProduct.ProductTypeID);

            ProductNameBox.Text = currProduct.Name;
            PriceBox.Text = currProduct.Price.ToString();
            StockBox.Text = currProduct.Stock.ToString();
            ProductTypeBox.Text = currProductType.Name;

            UpdateProductButton.Enabled = true;
            DeleteProductButton.Enabled = true;
            AddToCartButton.Visible = true;
        }


    }
}