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
    public partial class ViewProduct : System.Web.UI.Page
    {
        private static Product currProduct = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductTable.DataSource = ProductRepository.getAllProducts();
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

            ProductRepository.deleteProduct(currProduct.ID);
            currProduct = null;
            Response.Redirect(Request.RawUrl);
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
            currProduct = ProductRepository.getProductByID(productID);
            ProductType currProductType = ProductTypeRepository.getProductTypeByID(currProduct.ProductTypeID);

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