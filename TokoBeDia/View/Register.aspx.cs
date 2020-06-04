using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using TokoBeDia.Controller;

namespace TokoBeDia.View
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null) {
                Response.Redirect("Home.aspx");
            }
        }

        protected void doRegistration(object sender, EventArgs e)
        {
            string email = EmailBox.Text;
            string username = UsernameBox.Text;
            string password = PasswordBox.Text;
            string confirmPassword = ConfirmPasswordBox.Text;
            string gender = GenderButtons.Text;

            string error = UserController.signUp(email, username, password, confirmPassword, gender);

            if (error == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(),
                    "showalert", "alert('Registration successful!');", true);
                Response.Redirect("./Login.aspx");
            }
            else
            {
                ErrorMessage.Text = error;
            }
        }
    }
}