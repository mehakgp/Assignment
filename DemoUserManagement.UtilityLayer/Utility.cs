using System;
using System.Configuration;
using System.IO;

namespace DemoUserManagement.UtilityLayer
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

        public enum AddressTypeEnum
        {
            Current = 1,
            Permanent = 2
        }

        public enum ObjectTypeEnum
        {
            UserDetails = 1
        }


    }
}
