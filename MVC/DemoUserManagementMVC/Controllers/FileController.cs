using DemoUserManagementMVC.ModelView;
using DemoUserManagementMVC.UtilityLayer;
using DemoUserManangementMVC.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace DemoUserManagementMVC.Controllers
{
    public class FileController : Controller
    {
        [HttpPost]
        public ActionResult Upload()
        {
            try
            {
                HttpPostedFileBase file = Request.Files["file"];
                if (file == null || file.ContentLength == 0)
                {
                    return null; 
                }
                string fileName = file.FileName;
                string fileExtension = Path.GetExtension(fileName);
                string uploadFolderPath = ConfigurationManager.AppSettings["DocumentFilePath"];
                string uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                string filePath = Path.Combine(uploadFolderPath, uniqueFileName);
                file.SaveAs(filePath);
                return Content(uniqueFileName);
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
                return null;
            }
        }

        public ActionResult Download(int documentId)
        {
            DocumentModel document = new Business().GetDocument(documentId);

            string filePath = ConfigurationManager.AppSettings["DocumentFilePath"] + document.DocumentUniqueName;

            if (!System.IO.File.Exists(filePath))
            {
                return HttpNotFound("File not found.");
            }

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, document.DocumentOriginalName);
        }

        public ActionResult DownloadResume(int userID)
        {
           UserDetailsModel user = new Business().GetFileNameInUserDetails(userID);

            string filePath = ConfigurationManager.AppSettings["DocumentFilePath"] + user.UniqueFileName;

            if (!System.IO.File.Exists(filePath))
            {
                return HttpNotFound("File not found.");
            }

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, user.OriginalFileName);
        }
    }
}