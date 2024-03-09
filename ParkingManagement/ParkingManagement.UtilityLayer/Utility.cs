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

        public static string logFilePath = ConfigurationManager.AppSettings["logFilePath"];
        public static void LogException(Exception ex)
        {

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now} - Exception: {ex.Message}");
                writer.WriteLine($"StackTrace: {ex.StackTrace}");
                writer.WriteLine("--------------------------------------------------");
            }

        }

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
