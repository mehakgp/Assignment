using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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

        public static SessionModel UserSessionInfo
        {
            get
            {
                return HttpContext.Current.Session["UserSessionInfo"] as SessionModel;
            }
            set
            {
                HttpContext.Current.Session["UserSessionInfo"] = value;
            }
        }
    }
}
