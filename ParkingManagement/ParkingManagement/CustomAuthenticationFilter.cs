using System.Web.Mvc.Filters;
using System.Web.Mvc;
using ParkingManagement.ModelView;
using ParkingManagement.UtilityLayer;


namespace ParkingManagement
{
    public class CustomAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            SessionModel userSessionInfo = Utility.UserSessionInfo;

            if (userSessionInfo == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                    {
                        { "controller", "Home" },
                        { "action", "LogIn" }
                    });
            }
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
           
        }
    }
}
