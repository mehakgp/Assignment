using System.Configuration;
using System.IO;
using System.Web;

namespace DemoUserManagement
{

    public class DownloadFile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string fileName = context.Request.QueryString["fileName"];
            string filePath = ConfigurationManager.AppSettings["DocumentFilePath"] + fileName; 

            if (File.Exists(filePath))
            {
                context.Response.ContentType = "application/octet-stream";
                context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                context.Response.TransmitFile(filePath);
                context.Response.End();
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