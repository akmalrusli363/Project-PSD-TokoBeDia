using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Model;
using TokoBeDia.Controller;

namespace TokoBeDia.View.ProductTypes
{
    public partial class ViewProductType : System.Web.UI.Page
    {
        private static ProductType currProductType = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || !UserController.isAdmin(Int32.Parse(Session["user"].ToString())))
            {
                Response.Redirect("/View/Home.aspx");
                return;
            }

            ProductTypeTable.DataSource = ProductTypeController.getAllProductTypes();
            ProductTypeTable.DataBind();
        }

        protected void insertProductType(object sender, EventArgs e)
        {
            Response.Redirect("InsertProductType.aspx");
        }

        protected void updateProductType(object sender, EventArgs e)
        {
            if (currProductType == null)
            {
                return;
            }

            int currProductID = currProductType.ID;
            Response.Redirect("UpdateProductType.aspx?id=" + currProductID);
            currProductType = null;
        }

        protected void deleteProductType(object sender, EventArgs e)
        {
            if (currProductType == null)
            {
                return;
            }

            string error = ProductTypeController.deleteProductType(currProductType);

            if (error == "")
            {
                currProductType = null;
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                ErrorMessage.Text = error;
            }
        }

        protected void linkSelect_Click(object sender, EventArgs e)
        {
            int productID = Int32.Parse((sender as LinkButton).CommandArgument);
            currProductType = ProductTypeController.getProductTypeByID(productID);

            ProductTypeNameBox.Text = currProductType.Name;
            DescriptionBox.Text = currProductType.Description;

            UpdateProductTypeButton.Enabled = true;
            DeleteProductTypeButton.Enabled = true;
        }
    }
}