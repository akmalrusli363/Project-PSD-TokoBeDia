﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Model;
using TokoBeDia.Controller;

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
                userLoggedIn = UserController.getUserByID(Int32.Parse(userSession));
            }
        }

        protected void changePassword(object sender, EventArgs e)
        {
            string oldPassword = OldPasswordBox.Text;
            string newPassword = NewPasswordBox.Text;
            string confirmPassword = ConfirmPasswordBox.Text;

            string error = UserController.updatePassword(userLoggedIn, oldPassword, newPassword, confirmPassword);

            if (error == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                    "alertMessage", "alert('Update password successful!');", true);
                Response.Redirect("/Profile.aspx");
            }
            else
            {
                ErrorMessage.Text = error;
            }
        }
    }
}