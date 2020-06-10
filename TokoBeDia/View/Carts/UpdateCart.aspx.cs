using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Model;
using TokoBeDia.Controller;

// hati-hati, dilarang keras akses module repository tanpa buat handler dan controller lho!
using TokoBeDia.Repository;

namespace TokoBeDia.View.Carts
{
    public partial class UpdateCart : System.Web.UI.Page
    {
        private static Product currentProduct = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || UserController.isAdmin(Int32.Parse(Session["user"].ToString())))
            {
                Response.Redirect("/View/Home.aspx");
                return;
            }
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("ViewProduct.aspx");
                return;
            }
            if (!IsPostBack)
            {
                int productID = Int32.Parse(Request.QueryString["id"]);
                attachProperties(productID);
            }
        }
        private void attachProperties(int productID)
        {
            if (!IsPostBack)
            {
                currentProduct = ProductController.getProductByID(productID);
                ProductType currProductType = ProductTypeController.getProductTypeByID(currentProduct.ProductTypeID);
                int userId = Int32.Parse(Session["user"].ToString());
                Cart cart = CartRepository.getCartProductByUserID(productID, userId);
                ProductNameBox.Text = currentProduct.Name;
                PriceBox.Text = currentProduct.Price.ToString();
                StockBox.Text = currentProduct.Stock.ToString();
                ProductTypeBox.Text = currProductType.Name.ToString();
                QtyBox.Text = cart.Quantity.ToString();
            }
        }

        protected void UpdateCartButton_Click(object sender, EventArgs e)
        {
            int qty = Int32.Parse(QtyBox.Text);
            int productID = Int32.Parse(Request.QueryString["id"]);
            int userId = Int32.Parse(Session["user"].ToString());
            ErrorMessage.Text = CartController.DoUpdateCart(qty, productID, userId);
            if (ErrorMessage.Text == "")
            {
                Response.Redirect("ViewCart.aspx");
            }
        }
    }
}