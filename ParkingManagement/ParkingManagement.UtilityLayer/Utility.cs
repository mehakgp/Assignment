using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingManagement.ModelView;

namespace ParkingManagement.UtilityLayer
{
    public class Utility
    {

        public enum UserType
        {
            BookingCounterAgent,
            ParkingZoneAssistant
        }


        public static void SetUserSessionInfo(SessionModel userSessionInfo)
        {
            System.Web.HttpContext.Current.Session["UserSessionInfo"] = userSessionInfo;
        }

        public static SessionModel GetUserSessionInfo()
        {
            return System.Web.HttpContext.Current.Session["UserSessionInfo"] as SessionModel;

        }

       
    }
}
