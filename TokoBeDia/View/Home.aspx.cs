using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Model;
using TokoBeDia.Controller;

namespace TokoBeDia.View
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                String userSession = Session["user"].ToString();
                User userLoggedIn = UserController.getUserByID(Int32.Parse(userSession));
                String username = userLoggedIn.Name;
                usernameLabel.Text = username;
            }
            if (!IsPostBack)
            {
                listProducts.DataSource = ProductController.getRandomFiveProducts();
                listProducts.DataBind();
            }
        }
    }
}