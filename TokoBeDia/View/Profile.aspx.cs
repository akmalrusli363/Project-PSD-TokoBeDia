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
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) {
                Response.Redirect("/View/Login.aspx");
                return;
            }

            if (!IsPostBack) {
                User currUser = UserController.getUserByID(Int32.Parse(Session["user"].ToString()));
                String email = currUser.Email;
                String username = currUser.Name;
                String gender = currUser.Gender;

                EmailBox.Text = email;
                UsernameBox.Text = username;
                GenderBox.Text = gender;
            }
        }

        protected void updateProfile(object sender, EventArgs e)
        {
            Response.Redirect("/View/Users/UpdateProfile.aspx");
        }

        protected void changePassword(object sender, EventArgs e)
        {
            Response.Redirect("/View/Users/ChangePassword.aspx");
        }
    }
}