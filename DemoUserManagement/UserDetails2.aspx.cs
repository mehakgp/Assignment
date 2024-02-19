
using DemoUserManangement.BusinessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DemoUserManagement.ModelView.Model;
using static DemoUserManagement.UtilityLayer.Utility;

namespace DemoUserManagement
{
    public partial class UserDetails2 : Page
    {
        Business business = new Business();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["UserID"] != null)
                {
                    UserSessionInfo userSessionInfo = (UserSessionInfo)Session["UserSessionInfo"];
                    int SessionUserID = userSessionInfo.UserID;
                    bool SessionIsAdmin = userSessionInfo.IsAdmin;

                    string userSessionJson = JsonConvert.SerializeObject(userSessionInfo);
                    hdnUserSessionInfo.Value = userSessionJson;

                    int userID = Convert.ToInt32(Request.QueryString["UserID"]);

                    if (userID == SessionUserID || SessionIsAdmin)
                    {
                        NoteUserControl.ObjectID = userID;
                        NoteUserControl.ObjectType = (int)ObjectTypeEnum.UserDetails;

                        DocumentUserControl.ObjectID = userID;
                        DocumentUserControl.ObjectType = (int)ObjectTypeEnum.UserDetails;
                      
                        NoteUserControl.Visible = true;
                        DocumentUserControl.Visible = true;
                    }

                }
                else
                {
                    DocumentUserControl.Visible = false;
                    NoteUserControl.Visible = false;
                }
            }
        }

        [WebMethod]
        public static List<CountryModel> GetCountries()
        {
            Business business=new Business();
            List<CountryModel> countries = business.GetCountries();
            return countries;
        }

        [WebMethod]
        public static List<StateModel> GetStates(int CountryID)
        {
            Business business = new Business();
            List<StateModel> states = business.GetStates(CountryID);
            return states;
        }
       
        [WebMethod]
        public static string SubmitFormData(UserDetailsModel userDetails, AddressDetailsModel currentAddress, AddressDetailsModel permanentAddress, bool isAdmin)
        {
            try
            {
                Business business = new Business();
                if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["UserID"]))
                {
                    int userID = Convert.ToInt32(HttpContext.Current.Request.QueryString["UserID"]);
                    bool success = business.EditUserDetails(userDetails, currentAddress, permanentAddress, userID);
                    if (success)
                    {
                        if (isAdmin)
                        {
                            HttpContext.Current.Response.Redirect("~/Users.aspx");
                        }
                        else
                        {
                            return "{\"success\":true}";
                        }
                    }
                }
                else
                {
                    bool success = business.SaveUserDetails(userDetails, currentAddress, permanentAddress);
                    if (success)
                    {
                        HttpContext.Current.Response.Redirect("LogIn.aspx");
                    }
                }

                return "{\"success\":true}";
            }
            catch (Exception ex)
            {
                return "{\"success\":false,\"message\":\"" + ex.Message + "\"}";
            }
        }



        [WebMethod]
        public static string GetUserDetails(int userId)
        {
            Business business = new Business();
            UserDetailsModel userDetails = business.GetUserDetails(userId);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string userDetailsJson = serializer.Serialize(userDetails);
            return userDetailsJson;
        }
        [WebMethod]
        public static string GetAddressDetails(int userId,int addresssType)
        {
            Business business = new Business();
            AddressDetailsModel addressDetails=business.GetAddressDetails(userId,addresssType);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string addressDetailsJson = serializer.Serialize(addressDetails);
            return addressDetailsJson;


        }

   

        [WebMethod]
        public static bool CheckEmailExists(string email)
        {
            Business business = new Business();
            return business.CheckEmailExists(email);
        }


    }
}