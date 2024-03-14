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
                if (HttpContext.Current != null)
                {
                    return HttpContext.Current.Session["UserSessionInfo"] as SessionModel;
                }
                return null;

            }
            set
            {
                if(HttpContext.Current !=null)
                {
                    if(value != null)
                    {
                        HttpContext.Current.Session["UserSessionInfo"] = value;
                    }
                }
            }
        }
    }
}
