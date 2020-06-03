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
    public partial class UpdateProfile : System.Web.UI.Page
    {
        private static User userLoggedIn = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) {
                Response.Redirect("/View/Login.aspx");
                return;
            }
            else {
                if (!IsPostBack) {
                    fillProfileDetails();
                }
            }
        }

        private void fillProfileDetails()
        {
            String userSession = Session["user"].ToString();
            userLoggedIn = UserRepository.getUserByID(Int32.Parse(userSession));
            String email = userLoggedIn.Email;
            String username = userLoggedIn.Name;
            String gender = userLoggedIn.Gender;

            EmailBox.Text = email;
            UsernameBox.Text = username;
            GenderButtons.SelectedIndex = (gender.Equals("Male") ? 0 : 1);
        }

        protected void updateProfile(object sender, EventArgs e)
        {
            string email = EmailBox.Text;
            string username = UsernameBox.Text;
            string gender = GenderButtons.Text;

            if (!Regex.Match(email, "^[a-zA-Z0-9._-]+@[a-zA-Z0-9]+\\.[a-zA-Z]+$").Success) {
                ErrorMessage.Text = "Invalid email!";
                return;
            }
            else if (!Regex.Match(username, "[a-zA-Z0-9\\s]+").Success) {
                ErrorMessage.Text = "Invalid username!";
                return;
            }
            else if (!(gender.Equals("Male") || gender.Equals("Female"))) {
                ErrorMessage.Text = "You must select a gender!";
                return;
            }
            else if (!email.Equals(userLoggedIn.Email) && !UserRepository.verifyEmail(email)) {
                ErrorMessage.Text = "Your new email is already registered by another user! Please refresh to revert the changes!";
                return;
            }

            try {
                Repository.UserRepository.updateUser(userLoggedIn.ID, email, username, gender);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                ErrorMessage.Text = "Database update on server failure, please try again!";
                return;
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                "alertMessage", "alert('Update profile successful!');", true);
            Response.Redirect("/View/Profile.aspx");
        }
    }
}