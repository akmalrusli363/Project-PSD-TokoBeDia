using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;
using TokoBeDia.Model;

namespace TokoBeDia.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie rememberUserCookie = Request.Cookies["remember_user"];
            if (Session["user"] != null) {
                Response.Redirect("Home.aspx");
            }
            else if (rememberUserCookie != null 
                && !String.IsNullOrEmpty(rememberUserCookie.Value)) {
                String[] rememberUser = rememberUserCookie.Value.ToString().Split('\\');
                User login = Repository.UserRepository.login(rememberUser[0], rememberUser[1]);
                Session["user"] = login.ID;
                Response.Redirect("Home.aspx");
            }
        }

        protected void performLogin(object sender, EventArgs e)
        {
            String email = EmailBox.Text;
            String password = PasswordBox.Text;
            String errorMessage = "";
            User login = null;

            try {
                login = Repository.UserRepository.login(email, password);
            }
            catch (MemberAccessException ex) {
                errorMessage = ex.Message;
            }
            catch (Exception) {
                errorMessage = "Failed to login! (Invalid username/password!)";
            }

            if (login != null) {
                Session["user"] = login.ID;
                if (RememberMe.Checked) {
                    String remember_user = email + "\\" + password;
                    HttpCookie cookie = new HttpCookie("remember_user", remember_user);
                    cookie.Expires = DateTime.Now.AddHours(2);
                    Response.Cookies.Add(cookie);
                }
                Response.Redirect("Home.aspx");
            }

            else {
                ErrorMessage.Text = errorMessage;
            }
        }
    }
}