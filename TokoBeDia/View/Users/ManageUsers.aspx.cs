using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Model;
using TokoBeDia.Controller;

namespace TokoBeDia.View.Users
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        private static User selectedUser = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || !UserController.isAdmin(Int32.Parse(Session["user"].ToString())))
            {
                Response.Redirect("/View/Home.aspx");
                return;
            }
            UserTable.DataSource = UserController.getAllUsers();
            UserTable.DataBind();
        }

        protected void linkSelect_Click(object sender, EventArgs e)
        {
            int userID = Int32.Parse((sender as LinkButton).CommandArgument);
            selectedUser = UserController.getUserByID(userID);
            fillProfileDetails(selectedUser);

            EmailBox.Enabled = true;
            UsernameBox.Enabled = true;
            GenderBox.Enabled = true;
            RoleBox.Enabled = true;
            StatusButtons.Enabled = true;

            UpdateUserButton.Enabled = true;
        }

        private void fillProfileDetails(User selectedUser)
        {
            String email = selectedUser.Email;
            String username = selectedUser.Name;
            String gender = selectedUser.Gender;
            int role = selectedUser.RoleID;
            bool active = (selectedUser.Status == "active") ? true : false;

            EmailBox.Text = email;
            UsernameBox.Text = username;
            GenderBox.Text = gender;
            RoleBox.SelectedIndex = (role == 1) ? 0 : 1;
            StatusButtons.SelectedIndex = (active) ? 0 : 1;
        }

        protected void updateUser(object sender, EventArgs e)
        {
            if (selectedUser.ID == Int32.Parse(Session["user"].ToString()))
            {
                ErrorMessage.Text = "You cannot change current role/status of your user logged in!";
                return;
            }
            else
            {
                bool isAdmin = (RoleBox.SelectedIndex == 0);
                bool isBlocked = (StatusButtons.SelectedIndex == 1);

                string error = UserController.updateUserStatus(selectedUser, isAdmin, isBlocked);

                if (error == "")
                {
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    ErrorMessage.Text = error;
                    return;
                }
            }
        }
    }
}