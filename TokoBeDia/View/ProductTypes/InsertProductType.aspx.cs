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
    public partial class InsertProductType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || !UserRepository.isAdmin(Int32.Parse(Session["user"].ToString())))
            {
                Response.Redirect("/View/Home.aspx");
                return;
            }
        }

        protected void insertProductType(object sender, EventArgs e)
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
            else if (!ProductTypeRepository.validateProductTypeName(name))
            {
                ErrorMessage.Text = "These product type name has already taken!";
                return;
            }

            try
            {
                ProductTypeRepository.addProductType(name, description);
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