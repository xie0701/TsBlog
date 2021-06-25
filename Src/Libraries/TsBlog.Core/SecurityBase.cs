using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;

namespace TsBlog.Core
{
    public class SecurityBase
    {
        public static bool IsAuthorized
        {
            get
            {
                return CookieBase.Cookie == null ? false : bool.Parse(CookieBase.Cookie.Values["IsAuthorized"]);
            }
            set
            {
                HttpCookie httpCookie = CookieBase.Cookie == null ? CookieBase.NewCookie : CookieBase.Cookie;
                httpCookie.Values["IsAuthorized"] = value.ToString();
                CookieBase.Cookie = httpCookie;
            }
        }

        public static string UserName
        {
            get
            {
                return CookieBase.Cookie == null ? string.Empty : CookieBase.Cookie.Values["UserName"];
            }
            set
            {
                HttpCookie httpCookie = CookieBase.Cookie == null ? CookieBase.NewCookie : CookieBase.Cookie;
                httpCookie.Values["UserName"] = value;
                CookieBase.Cookie = httpCookie;
            }
        }

        public static void RemoveCookie()
        {
            CookieBase.RemoveCookie();
        }
    }
}
