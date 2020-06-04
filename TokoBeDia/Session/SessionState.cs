using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;

namespace TokoBeDia.Session
{
    public class SessionState
    {
        public static HttpCookie createCookie(string name, string value, double hours)
        {
            HttpCookie cookie = new HttpCookie(name);
            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddHours(hours);
            return cookie;
        }

        public static void destroyCookie(HttpCookie cookie)
        {
            if (cookie == null) {
                return;
            }
            cookie.Value = null;
            cookie.Expires = DateTime.Now.AddYears(-1);
            cookie = null;
        }

        public static int getUserSessionID(Page page)
        {
            return Int32.Parse(page.Session["user"].ToString());
        }

        public static bool isAdmin(Page page)
        {
            return page.Session["user"] == null
                || !UserController.isAdmin(Int32.Parse(page.Session["user"].ToString()));
        }

        public static bool isLoggedIn(Page page)
        {
            return page.Session["user"] == null;
        }
    }
}