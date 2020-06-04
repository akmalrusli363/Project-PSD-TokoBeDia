using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;
using TokoBeDia.Model;

namespace TokoBeDia.View.ProductTypes
{
    public partial class InsertProductType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || !UserController.isAdmin(Int32.Parse(Session["user"].ToString())))
            {
                Response.Redirect("/View/Home.aspx");
                return;
            }
        }

        protected void insertProductType(object sender, EventArgs e)
        {
            string name = ProductTypeNameBox.Text;
            string description = DescriptionBox.Text;

            string error = ProductTypeController.insertProductType(name, description);

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