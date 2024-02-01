using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ENTITY_FRAMEWORK.UtilityLayer
{
    public class Utility
    {
        public static string logFilePath = "C:\\Users\\mehakg\\Desktop\\Projects\\Assignment\\CRUD_ENTITY_FRAMEWORK.UtilityLayer\\LogFile.txt";

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
                string ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (var connection = new SqlConnection(ConString))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO LogException (LogTime, ExceptionMessage, StackTrace) VALUES (@LogTime, @ExceptionMessage, @StackTrace)";

                        command.Parameters.AddWithValue("@LogTime", DateTime.Now);
                        command.Parameters.AddWithValue("@ExceptionMessage", ex.Message);
                        command.Parameters.AddWithValue("@StackTrace", ex.StackTrace);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception logEx)
            {
                Console.WriteLine($"Error writing to log file: {logEx.Message}");
            }
        }
        public enum CrudOperation
        {
            Create = 1,
            Read,
            Update,
            Delete,
            Export,
            Exit
        }

        public enum EntityChoice
        {
            Student = 1,
            Teacher,
            Course,
            Enrollment,
            Exit
        }
        public enum ChoiceForReadOperation
        {
            Student = 1,
            Teacher,
            Course,
            Enrollment,
            StudentsInCourse,
            CoursesByStudent,
            Exit
        }
        public enum ExportFormat
        {
        Excel=1,
        CSV
        }
    }
}
