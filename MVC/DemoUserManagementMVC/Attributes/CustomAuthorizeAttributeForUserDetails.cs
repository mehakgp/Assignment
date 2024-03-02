using DemoUserManagementMVC.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DemoUserManagementMVC.UtilityLayer.Utility;

namespace DemoUserManagementMVC.Attributes
{
    public class CustomAuthorizeAttributeForUserDetails : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (httpContext.Request.RequestContext.RouteData.Values["id"] != null)
            {
                int urlUserID = Convert.ToInt32(httpContext.Request.RequestContext.RouteData.Values["id"]);
                SessionModel sessionInfo = GetUserSessionInfo();

                if (sessionInfo != null)
                {
                    if (urlUserID == sessionInfo.UserID || sessionInfo.IsAdmin)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            else
            {
                return true;
            }


        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            SessionModel sessionInfo = GetUserSessionInfo();
            if (sessionInfo != null)
            {
                filterContext.Result = new RedirectResult("~/UserDetails/UserDetailsForm/" + sessionInfo.UserID);
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
            }
        }

    }
}