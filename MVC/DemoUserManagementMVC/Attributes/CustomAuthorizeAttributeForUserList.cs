using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DemoUserManagementMVC.UtilityLayer.Utility;
using DemoUserManagementMVC.ModelView;

namespace DemoUserManagementMVC.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorizeAttributeForUserList : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            SessionModel sessionInfo = GetUserSessionInfo();

            if (sessionInfo != null)
            {
                return sessionInfo.IsAdmin;
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Home/Index");
        }
    }
}