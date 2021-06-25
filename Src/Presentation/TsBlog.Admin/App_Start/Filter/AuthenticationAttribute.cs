using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TsBlog.Core;
using TsBlog.Core.Operator;

namespace TsBlog.Admin.App_Start.Filter
{
    public class AuthenticationAttribute : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var IsAuthorized = false;
            if (httpContext != null && httpContext.Session != null)
            {
                var token = httpContext.Request.Cookies["authToken"] == null ? "" : httpContext.Request.Cookies["authToken"].Value;
                if (OperatorProvider.Provider.GetCurrent() != null)
                    IsAuthorized = true;
                if (string.IsNullOrEmpty(token))
                    IsAuthorized = false;
                else
                {
                    try
                    {
                        string info = JwtHelper.GetJwtDecode(token);
                    }
                    catch (Exception ex)
                    {
                        IsAuthorized = false;
                    }
                }
            }
            return IsAuthorized;
        }

        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    var operatorInfo = OperatorProvider.Provider.GetCurrent();

        //    if (operatorInfo == null)
        //    {
        //        WebHelper.WriteCookie("nfine_login_error", "overdue");
        //        filterContext.HttpContext.Response.Write("<script>top.location.href = '/Admin/Login/Index';</script>");
        //        return;
        //    }
        //}

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var routeValue = new RouteValueDictionary{
                {"Controller", "Login"},
                {"Action", "Index"},
                {"Area", "Admin"}
            };
            filterContext.Result = new RedirectToRouteResult(routeValue);
        }
    }
}