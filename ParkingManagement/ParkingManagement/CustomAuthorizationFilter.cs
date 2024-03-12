using ParkingManagement.UtilityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkingManagement.ModelView;

namespace ParkingManagement
{
    public class CustomAuthorizationFilter : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            SessionModel userSessionInfo = Utility.UserSessionInfo;
            if (String.Equals(userSessionInfo.Type, Utility.UserType.BookingCounterAgent.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Dashboard/Index");
        }
    }

}