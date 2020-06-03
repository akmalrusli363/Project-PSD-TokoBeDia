using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using TokoBeDia.Repository;

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

            if (!Regex.Match(email, "^[a-zA-Z0-9._-]+@[a-zA-Z0-9]+\\.[a-zA-Z]+$").Success)
            {
                ErrorMessage.Text = "Invalid email!";
                return;
            }
            else if (!Regex.Match(username, "[a-zA-Z0-9\\s]+").Success)
            {
                ErrorMessage.Text = "Invalid username!";
                return;
            }
            else if (!password.Equals(confirmPassword))
            {
                ErrorMessage.Text = "Password and confirm password must be same!";
                return;
            }
            else if (!(gender.Equals("Male") || gender.Equals("Female")))
            {
                ErrorMessage.Text = "You must select a gender (unless you're nonbinary gender, hotline: 1500-LGBT)!";
                return;
            }
            else if (!UserRepository.verifyEmail(email)) {
                ErrorMessage.Text = "Email is already registered by another user!";
                return;
            }

            try
            {
                Repository.UserRepository.signUp(email, username, password, gender);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ErrorMessage.Text = "Database update on server failure, please try again!";
                return;
            }

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(),
                "showalert", "alert('Registration successful!');", true);
            Response.Redirect("./Login.aspx");
        }
    }
}