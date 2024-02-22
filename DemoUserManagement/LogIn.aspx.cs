using DemoUserManangement.BusinessLayer;
using System;
using System.Web.Services;
using System.Web.UI;
using static DemoUserManagement.ModelView.Model;
using static DemoUserManagement.UtilityLayer.Utility;

namespace DemoUserManagement
{
    public partial class LogIn : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        [WebMethod]
        public static LogInResponse ValidateUser(string email, string password)
        {
            Business business = new Business();
            int userID = business.GetUserByEmailAndPassword(email, password);
            bool isAdmin = business.CheckIfUserIsAdmin(userID);
            if (userID != -1)
            {
               
                SessionModel userSessionInfo = new SessionModel
                {
                    UserID = userID,
                    IsAdmin = isAdmin
                };

                SetUserSessionInfo(userSessionInfo);
            }
            return new LogInResponse
            {
                userID = userID,
                IsAdmin = isAdmin,
            };
        }

    }


}
