using DemoUserManagementMVC.Attributes;
using DemoUserManagementMVC.ModelView;
using DemoUserManangementMVC.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DemoUserManagementMVC.UtilityLayer.Utility;

namespace DemoUserManagementMVC.Controllers
{
    public class UserDetails2Controller : Controller
    {

        public ActionResult UserDetailsForm2()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetStates(int CountryID)
        {
            List<StateModel> states = new Business().GetStates(CountryID);
            return Json(states, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetCountries()
        {
            List< CountryModel> model = new Business().GetCountries();
            return Json(model, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult SubmitFormData(UserDetailsModel userDetails, AddressDetailsModel currentAddress, AddressDetailsModel permanentAddress, int userID)
        {
            SubmitFormDataResponse response= new Business().SubmitFormDataResponse(userDetails,currentAddress, permanentAddress, userID);
            return Json(response);
        }

        [HttpGet]
        [CustomAuthorizeAttributeForUserDetails]
        public ActionResult GetFormDetails(int userId)
        {
            UserModel user = new Business().GetFormDetails(userId);
            return Json(new { UserDetails = user.UserDetails, CurrentAddress = user.CurrentAddress, PermanentAddress = user.PermanentAddress }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CheckEmailExists(string email, int userID)
        {
            return Json(new Business().CheckEmailExists(email, userID), JsonRequestBehavior.AllowGet);
        }
    }
}