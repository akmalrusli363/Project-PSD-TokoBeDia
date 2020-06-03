using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;

namespace TokoBeDia.View
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logout(object sender, EventArgs e)
        {
            HttpCookie voidUser = Request.Cookies["remember_user"];
            voidUser = new HttpCookie("remember_user");
            voidUser.Value = "";
            voidUser.Expires = DateTime.Now.AddYears(-1);
            Response.SetCookie(voidUser);

            Session.Clear();
            Session.Abandon();
            Response.Redirect("/View/Home.aspx");
        }
    }
}