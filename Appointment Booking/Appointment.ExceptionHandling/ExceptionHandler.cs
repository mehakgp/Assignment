using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SchoolManagement.ExceptionHandling
{
    public class ExceptionHandler
    {

        private readonly string _logFilePath;

        public ExceptionHandler(IConfiguration configuration)
        {
            _logFilePath = configuration["Logging:FilePath"];
        }
        public void LogException(Exception ex)
        {
            if (!File.Exists(_logFilePath))
            {
                using (FileStream fs = File.Create(_logFilePath)) { }
            }

            using (StreamWriter writer = new StreamWriter(_logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now} - Exception: {ex.Message}");
                writer.WriteLine($"StackTrace: {ex.StackTrace}");
                writer.WriteLine("--------------------------------------------------");
            }
        }
    }
}
