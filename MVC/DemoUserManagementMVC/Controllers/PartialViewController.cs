using DemoUserManagementMVC.ModelView;
using DemoUserManagementMVC.UtilityLayer;
using DemoUserManangementMVC.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUserManagementMVC.Controllers
{
    public class PartialViewController : Controller
    {



        public JsonResult GetNoteData(int objectID, int objectType, int page = 1, int pageSize = 3, string sortExpression = "ID", string sortDirection = "ASC")
        {
        
            List<NoteModel> noteList = new Business().GetNotes(objectID, objectType, page, pageSize, sortExpression, sortDirection);
            int total= new Business().GetTotalPagesOfNote(objectID, objectType,pageSize);
            
            var result = new
            {
                notes = noteList,
                totalPages = total
            };

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        
        public JsonResult AddNote(int objectID, int objectType, string note)
        {
         bool success= new Business().InsertNote(objectID, objectType, note);
            if(success)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
            
        }


        public JsonResult GetDocumentData(int objectID, int objectType, int page = 1, int pageSize = 3, string sortExpression = "ID", string sortDirection = "ASC")
        {
            List<DocumentModel> documentList = new Business().GetDocuments(objectID, objectType, page, pageSize, sortExpression, sortDirection);
            int total=new Business().GetTotalPagesOfDocument(objectID,objectType,pageSize);
            var result = new
            {
                documents = documentList,
                totalPages = total
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult StoreDocument(int objectID, int objectType, int documentType, string documentOriginalName, string documentUniqueName)
        {
       
           bool success= new Business().SaveDocument(objectID,objectType,documentType,documentOriginalName,documentUniqueName);
            if (success)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }


        public JsonResult GetDocumentTypes(int objectType)
        {
            var documentTypes = Utility.GetDocumentTypes(objectType);
            return Json(documentTypes, JsonRequestBehavior.AllowGet);
        }

   

    }
}