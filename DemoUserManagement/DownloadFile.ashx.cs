using DemoUserManangement.BusinessLayer;
using System;
using System.Configuration;
using System.IO;
using System.Web;

namespace DemoUserManagement
{

    public class DownloadFile : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        //works for both-- document user control & userdetails document input
        public void ProcessRequest(HttpContext context)
        {
            int userId = Convert.ToInt32(context.Request.QueryString["userID"]);


            if (userId == BasePage.GetSessionUserId() || BasePage.IsAdmin())
            {
                Business business = new Business();
                string documentId = context.Request.QueryString["documentID"];   
                if (!string.IsNullOrEmpty(documentId))
                {
                    if (!int.TryParse(documentId, out int id))
                    {
                        context.Response.StatusCode = 400;
                        context.Response.End();
                        return;
                    }
                 
                    string fileName = business.GetDocumentUniqueNameById(id);
                    string filePath = ConfigurationManager.AppSettings["DocumentFilePath"] + fileName;

                    if (File.Exists(filePath))
                    {
                        context.Response.ContentType = "application/octet-stream";
                        context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                        context.Response.TransmitFile(filePath);
                        context.Response.End();
                    }
                }


                else
                {
                    string fileName = business.GetUniqueFileNameInUserDetails(userId);
                    string filePath = ConfigurationManager.AppSettings["DocumentFilePath"] + fileName;

                    if (File.Exists(filePath))
                    {
                        context.Response.ContentType = "application/octet-stream";
                        context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                        context.Response.TransmitFile(filePath);
                        context.Response.End();
                    }

                }
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