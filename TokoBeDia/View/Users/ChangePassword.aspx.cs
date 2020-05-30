using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.View.Profiles
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        private static User userLoggedIn = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) {
                Response.Redirect("/View/Login.aspx");
                return;
            } else {
                String userSession = Session["user"].ToString();
                userLoggedIn = UserRepository.getUserByID(Int32.Parse(userSession));
            }
        }

        protected void changePassword(object sender, EventArgs e)
        {
            string oldPassword = OldPasswordBox.Text;
            string newPassword = NewPasswordBox.Text;
            string confirmPassword = ConfirmPasswordBox.Text;

            if (!oldPassword.Equals(userLoggedIn.Password)) {
                ErrorMessage.Text = "Invalid current password!";
                return;
            } if (confirmPassword.Equals(newPassword)) {
                ErrorMessage.Text = "Confirm password isn't match with new password!";
                return;
            }


            try {
                Repository.UserRepository.updatePassword(userLoggedIn.ID, newPassword);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                ErrorMessage.Text = "Database update on server failure, please try again!";
                return;
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                "alertMessage", "alert('Update password successful!');", true);
            Response.Redirect("/Profile.aspx");
        }
    }
}