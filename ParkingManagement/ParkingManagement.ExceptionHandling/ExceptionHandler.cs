using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement.ExceptionHandling
{
    public class ExceptionHandler
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
    }
}
