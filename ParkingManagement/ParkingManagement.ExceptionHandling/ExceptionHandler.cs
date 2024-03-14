using System;
using System.Configuration;
using System.IO;

namespace ParkingManagement.ExceptionHandling
{
    public class ExceptionHandler
    {
        public static string logFilePath = ConfigurationManager.AppSettings["logFilePath"];
        public static void LogException(Exception ex)
        {
            if (!File.Exists(logFilePath))
            {
                using (FileStream fs = File.Create(logFilePath)) { }
            }

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now} - Exception: {ex.Message}");
                writer.WriteLine($"StackTrace: {ex.StackTrace}");
                writer.WriteLine("--------------------------------------------------");
            }

        }
    }
}
