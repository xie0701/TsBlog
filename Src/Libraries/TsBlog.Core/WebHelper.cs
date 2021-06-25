using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TsBlog.Core
{
    public class WebHelper
    {
        #region ======操作Session======
        public static void WriteSession<T>(string key, T value)
        {
            if (string.IsNullOrEmpty(key))
                return;
            HttpContext.Current.Session[key] = value;
        }

        public static void WriteSession(string key, string value)
        {
            WriteSession<string>(key, value);
        }

        public static string GetSession(string key)
        {
            if (string.IsNullOrEmpty(key))
                return string.Empty;
            return HttpContext.Current.Session[key] as string;
        }

        public static void RemoveSession(string key)
        {
            if (string.IsNullOrEmpty(key))
                return;
            HttpContext.Current.Session.Contents.Remove(key);
        }
        #endregion

        #region ======操作Cookie======
        public static void WriteCookie(string name, string value)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie == null)
                cookie = new HttpCookie(name);
            cookie.Value = value;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static void WriteCookie(string name, string value, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie == null)
                cookie = new HttpCookie(name);
            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static string GetCookie(string name)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[name] != null)
            {
                return HttpContext.Current.Request.Cookies[name].Value.ToString();
            }
            return string.Empty;
        }

        public static void RemoveCookie(string name)
        {
            HttpCookie cookie = new HttpCookie(name);
            cookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        #endregion
    }
}
