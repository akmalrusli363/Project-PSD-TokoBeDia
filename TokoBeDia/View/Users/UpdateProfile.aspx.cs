using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Model;
using TokoBeDia.Controller;

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
            userLoggedIn = UserController.getUserByID(Int32.Parse(userSession));
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

            string error = UserController.updateUserProfile(userLoggedIn, email, username, gender);

            if (error == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                    "alertMessage", "alert('Update profile successful!');", true);
                Response.Redirect("/View/Profile.aspx");
            }
            else
            {
                ErrorMessage.Text = error;
            }
        }
    }
}