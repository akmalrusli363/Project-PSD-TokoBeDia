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
    public partial class UpdateProductType : System.Web.UI.Page
    {
        private static ProductType currentProductType = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || !UserController.isAdmin(Int32.Parse(Session["user"].ToString())))
            {
                Response.Redirect("/View/Home.aspx");
                return;
            }
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("ViewProductType.aspx");
                return;
            }
            if (!IsPostBack)
            {
                int productTypeID = Int32.Parse(Request.QueryString["id"]);
                attachProperties(productTypeID);
            }
        }

        private void attachProperties(int productTypeID)
        {
            if (!IsPostBack)
            {
                currentProductType = ProductTypeController.getProductTypeByID(productTypeID);
                if (currentProductType == null) {
                    Response.Redirect("ViewProductType.aspx");
                    return;
                }
                ProductTypeNameBox.Text = currentProductType.Name;
                DescriptionBox.Text = currentProductType.Description.ToString();
            }
        }

        protected void updateProductType(object sender, EventArgs e)
        {
            string name = ProductTypeNameBox.Text;
            string description = DescriptionBox.Text;

            string error = ProductTypeController.updateProductType(currentProductType, name, description);

            if (error == "")
            {
                Response.Redirect("ViewProductType.aspx");
            }
            else
            {
                ErrorMessage.Text = error;
            }
        }
    }
}