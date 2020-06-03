using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TokoBeDia.Repository
{
    public class SessionStateRepository
    {
        public static HttpCookie createCookie(String name, String value, double hours)
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
    }
}