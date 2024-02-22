using System;
using System.Configuration;
using System.IO;
using System.Web;
using static DemoUserManagement.UtilityLayer.Utility;

namespace DemoUserManagement
{
    public class UploadFileHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                if (context.Request.Files.Count > 0)
                {
                    HttpPostedFile file = context.Request.Files[0];
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string uploadFolderPath = ConfigurationManager.AppSettings["DocumentFilePath"];
                    string filePath = Path.Combine(uploadFolderPath, uniqueFileName);
                    file.SaveAs(filePath);
                    context.Response.Write(uniqueFileName);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                context.Response.Write("Error: " + ex.Message);
            }
        }
/// <summary>
/// for previous userdetails page
/// </summary>

        public string UploadFile(HttpPostedFile file, string uploadFolderPath)
        {
            try
            {
                string fileName = file.FileName;
                string fileExtension = Path.GetExtension(fileName);
                string uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                string filePath = Path.Combine(uploadFolderPath, uniqueFileName);
                file.SaveAs(filePath);
                return uniqueFileName;
            }
            catch (Exception ex)
            {
                LogException(ex);
                return null;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}

