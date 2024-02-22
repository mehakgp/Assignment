
using DemoUserManagement.UtilityLayer;
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
    public partial class UserDetails2 : BasePage
    {
        Business business = new Business();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["UserID"] != null)
                {

                    int userID = Convert.ToInt32(Request.QueryString["UserID"]);

                    NoteUserControl.ObjectID = userID;
                    NoteUserControl.ObjectType = (int)ObjectTypeEnum.UserDetails;

                    DocumentUserControl.ObjectID = userID;
                    DocumentUserControl.ObjectType = (int)ObjectTypeEnum.UserDetails;

                    NoteUserControl.Visible = true;
                    DocumentUserControl.Visible = true;


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
            return new Business().GetCountries();
        }

        [WebMethod]
        public static List<StateModel> GetStates(int CountryID)
        {
            return new Business().GetStates(CountryID);
        }


        [WebMethod]
        public static SubmitFormDataResponse SubmitFormData(UserDetailsModel userDetails, AddressDetailsModel currentAddress, AddressDetailsModel permanentAddress, int userID)
        {
            SubmitFormDataResponse response = new SubmitFormDataResponse();
            try
            {
                Business business = new Business();
                if (userID != 0)
                {
                    if (userID == GetSessionUserId() || IsAdmin())
                    {
                        bool success = business.EditUserDetails(userDetails, currentAddress, permanentAddress, userID);
                        if (success)
                        {
                            response.EditSuccess = true;
                            response.IsAdmin = IsAdmin();
                        }
                    }
                }
                else
                {
                    bool success = business.SaveUserDetails(userDetails, currentAddress, permanentAddress);
                    if (success)
                    {
                        response.NewUserSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
            return response;
        }



        [WebMethod]
        public static UserDetailsModel GetUserDetails(int userId)
        {
            if (userId == GetSessionUserId() || IsAdmin())
                return new Business().GetUserDetails(userId);
            else
                return new UserDetailsModel();
        }

        [WebMethod]
        public static AddressDetailsModel GetAddressDetails(int userId, int addressType)
        {
            if (userId == GetSessionUserId() || IsAdmin())
                return new Business().GetAddressDetails(userId, addressType);
            else
                return new AddressDetailsModel();
        }

        [WebMethod]
        public static bool CheckEmailExists(string email, int userID)
        {

            return new Business().CheckEmailExists(email, userID);

        }


    }
}