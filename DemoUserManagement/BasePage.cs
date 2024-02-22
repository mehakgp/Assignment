using DemoUserManagement.UtilityLayer;
using DemoUserManangement.BusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using static DemoUserManagement.ModelView.Model;

namespace DemoUserManagement
{
    public class BasePage :System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string pageName = Path.GetFileName(Request.Url.LocalPath).ToLower(); 
            SessionModel objSession = Utility.GetUserSessionInfo();

            if (objSession == null && pageName != "login.aspx" && pageName != "userdetails2.aspx")
            { 
                Response.Redirect("LogIn.aspx"); 
            }
            else
            {

                switch (pageName)
                {
                    case "users.aspx":
                        if (!IsAdmin())
                        {
                            Response.Redirect($"UserDetails2.aspx?UserID={objSession.UserID}");
                        }
                        
                        break;
                    case "userdetails2.aspx":
                        if (string.IsNullOrWhiteSpace(Request.QueryString["UserID"]) || Convert.ToInt32(Request.QueryString["UserID"]) <= 0 &&
                            (objSession == null))
                        {
                            // nothing to do here - signup
                        }
                        else if (Convert.ToInt32(Request.QueryString["UserID"]) != GetSessionUserId() && !IsAdmin())
                        {
                            if(objSession!=null)
                            {
                                Response.Redirect($"UserDetails2.aspx?UserID={objSession.UserID}");
                            }
                            else
                            {
                                Response.Redirect("LogIn.aspx");
                            }
                          
                        }
                        break;
                    case "login.aspx":
                        if (objSession!=null&& IsAdmin())
                        {
                            Response.Redirect("Users.aspx");
                        }
                        else if(objSession!=null)
                        {
                            Response.Redirect($"UserDetails2.aspx?UserID={objSession.UserID}");
                        }
                        break;
                }
            }
        }

        public static bool IsAdmin()
        {
            SessionModel obj = Utility.GetUserSessionInfo();
            if (obj != null)
                return obj.IsAdmin;
            else return false;
        }

        public static int GetSessionUserId()
        {
            SessionModel obj = Utility.GetUserSessionInfo();
            if (obj != null)
            {
                  return obj.UserID;
            }
            else
            {
                return -1;
            }
        }


        [WebMethod]
        public static void StoreDocument(int objectID, int objectType, int documentType, string documentOriginalName, string documentUniqueName)
        {
            var doc = new DocumentModel
            {
                ObjectID = objectID,
                ObjectType = objectType,
                DocumentType = documentType,
                DocumentOriginalName = documentOriginalName,
                DocumentUniqueName = documentUniqueName
            };
            Business business = new Business();
            business.SaveDocument(doc);
        }

    }

}