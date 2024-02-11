using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUserManagement.UtilityLayer
{
    public class Utility
    {

        public static string logFilePath = ConfigurationManager.AppSettings["logFilePath"];
        public static void LogException(Exception ex)
        {
            try
            {
                Console.WriteLine("Exception occured. Check log file ");
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now} - Exception: {ex.Message}");
                    writer.WriteLine($"StackTrace: {ex.StackTrace}");
                    writer.WriteLine("--------------------------------------------------");
                }
                //string ConString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
                //using (var connection = new SqlConnection(ConString))
                //{
                //    connection.Open();

                //    using (var command = connection.CreateCommand())
                //    {
                //        command.CommandText = "INSERT INTO LogException (LogTime, ExceptionMessage, StackTrace) VALUES (@LogTime, @ExceptionMessage, @StackTrace)";

                //        command.Parameters.AddWithValue("@LogTime", DateTime.Now);
                //        command.Parameters.AddWithValue("@ExceptionMessage", ex.Message);
                //        command.Parameters.AddWithValue("@StackTrace", ex.StackTrace);

                //        command.ExecuteNonQuery();
                //    }
                //}
            }
            catch (Exception logEx)
            {
                Console.WriteLine($"Error writing to log file: {logEx.Message}");
            }
        }
    }
}
