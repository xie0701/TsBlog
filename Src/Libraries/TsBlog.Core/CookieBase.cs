using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;

namespace TsBlog.Core
{
    public abstract class CookieBase
    {
        private static HttpResponse Response
        {
            get
            {
                return HttpContext.Current.Response;
            }
        }

        private static HttpRequest Request
        {
            get
            {
                return HttpContext.Current.Request;
            }
        }

        public static HttpCookie Cookie
        {
            get
            {
                return Request.Cookies["CookieBase"] as HttpCookie;
            }
            set
            {
                if (Request.Cookies["CookieBase"] != null)
                    Request.Cookies.Remove("CookieBase");
                Response.Cookies.Add(value);
            }
        }

        public static HttpCookie NewCookie
        {
            get
            {
                return new HttpCookie("CookieBase");
            }
        }

        public static void RemoveCookie()
        {
            if (Cookie == null)
                Response.Cookies.Remove("CookieBase");
            else
                Response.Cookies["CookieBase"].Expires = DateTime.Now.AddDays(-1);
        }
    }
}
