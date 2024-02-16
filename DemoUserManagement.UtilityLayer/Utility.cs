using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using static DemoUserManagement.ModelView.Model;

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

        public static List<DocumentTypeModel> GetDocumentTypes(int ObjectType)
        {
            List<DocumentTypeModel> doc = new List<DocumentTypeModel>();

            if (ObjectType == (int)ObjectTypeEnum.UserDetails)
            {
                doc.Add(new DocumentTypeModel { DocumentId = 1, DocumentTypeName = "PAN Card" });
                doc.Add(new DocumentTypeModel { DocumentId = 2, DocumentTypeName = "Aadhar Card" });
                doc.Add(new DocumentTypeModel { DocumentId = 3, DocumentTypeName = "VoterID Card" });
            }

            return doc;
        }

    }
}

