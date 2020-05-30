using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;
using TokoBeDia.Model;

namespace TokoBeDia.View.ProductTypes
{
    public partial class UpdateProductType : System.Web.UI.Page
    {
        private static ProductType currentProductType = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || !UserRepository.isAdmin(Int32.Parse(Session["user"].ToString())))
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
                currentProductType = ProductTypeRepository.getProductTypeByID(productTypeID);
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

            if (name.Length < 5)
            {
                ErrorMessage.Text = "Name must at least 5 characters!";
                return;
            }
            else if (description.Length <= 0)
            {
                ErrorMessage.Text = "Description must not be empty!";
                return;
            }
            else if (!name.Equals(currentProductType.Name) &&
                !ProductTypeRepository.validateProductTypeName(name))
            {
                ErrorMessage.Text = String.Format("These product type name has already taken! " + 
                    "Use old name: '{0}' or other non-existent product type instead.", currentProductType.Name);
                return;
            }

            try
            {
                ProductTypeRepository.updateProductType(currentProductType.ID, name, description);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ErrorMessage.Text = "Database update on server failure, please try again!";
                return;
            }
            Response.Redirect("ViewProductType.aspx");
        }
    }
}