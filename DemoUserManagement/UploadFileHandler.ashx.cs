using DemoUserManangement.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Web;
using static DemoUserManagement.ModelView.Model;
using static DemoUserManagement.UtilityLayer.Utility;

namespace DemoUserManagement
{
    public class UploadFileHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if (context.Request.Files.Count > 0)
                {
                    HttpPostedFile postedFile = context.Request.Files[0];
                    string fileName = Path.GetFileName(postedFile.FileName);
                    string fileExtension = Path.GetExtension(fileName);
                    string uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                    string uploadFolderPath = ConfigurationManager.AppSettings["DocumentFilePath"];
                    string filePath = Path.Combine(uploadFolderPath, uniqueFileName);
                    postedFile.SaveAs(filePath);

                    int objectID = int.Parse(context.Request.QueryString["ObjectID"]);
                    int objectType = int.Parse(context.Request.QueryString["ObjectType"]);
                    int documentType = int.Parse(context.Request.QueryString["DocumentType"]);

                    var doc = new DocumentModel
                    {
                        ObjectID = objectID,
                        ObjectType = objectType,
                        DocumentType = documentType,
                        DocumentOriginalName = fileName,
                        DocumentUniqueName = uniqueFileName
                    };

                    Business business = new Business();
                    business.SaveDocument(doc);
                    context.Response.StatusCode = 200;
                }
                else
                {
                    context.Response.StatusCode = 400;
                }
            }
            catch (Exception ex)
            {

                LogException(ex);
                context.Response.StatusCode = 500;
            }
            finally
            {
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

