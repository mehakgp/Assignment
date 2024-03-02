using DemoUserManagementMVC.ModelView;
using DemoUserManagementMVC.UtilityLayer;
using DemoUserManangementMVC.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUserManagementMVC.Attributes;

namespace DemoUserManagementMVC.Controllers
{
    public class UserDetailsController : Controller
    {

        Business business = new Business();



        [HttpGet]
        public ActionResult GetStatesByCountry(int countryId)
        {
            var states = business.GetStates(countryId);
            return Json(states, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        [CustomAuthorizeAttributeForUserDetails]
        public ActionResult UserDetailsForm(int? id)
        {
            UserModel user = new UserModel();
            ViewBag.Countries = new SelectList(business.GetCountries(), "CountryID", "CountryName");

            if (id.HasValue && id > 0)
            {

                user = business.GetFormDetails(id.Value);
                ViewBag.CurrentStates = new SelectList(business.GetStates(user.CurrentAddress.CountryID), "StateID", "StateName");
                ViewBag.PermanentStates = new SelectList(business.GetStates(user.PermanentAddress.CountryID), "StateID", "StateName");
            }
            return View(user);
        }





        [HttpPost]
        [CustomAuthorizeAttributeForUserDetails]
        public ActionResult UserDetailsForm(UserModel user, int? id)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Countries = new SelectList(business.GetCountries(), "CountryID", "CountryName");
                return View(user);
            }
            if (id.HasValue && id > 0)
            {
                if (business.EditUserDetails(user, id.Value))
                {
                    SessionModel userSessionInfo = Utility.GetUserSessionInfo();
                    if (userSessionInfo != null && userSessionInfo.IsAdmin)
                    {
                        return RedirectToAction("UserList", "Users");
                    }
                    else
                    {

                        ViewBag.Countries = new SelectList(business.GetCountries(), "CountryID", "CountryName");
                        ViewBag.CurrentStates = new SelectList(business.GetStates(user.CurrentAddress.CountryID), "StateID", "StateName");
                        ViewBag.PermanentStates = new SelectList(business.GetStates(user.PermanentAddress.CountryID), "StateID", "StateName");
                        ViewBag.Message = "Details edited successfully.";
                    }
                }
            }
            else
            {
                bool success = business.SaveUserDetails(user);
                if (success)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(user);
        }

        [HttpPost]
        public JsonResult CheckEmailExists(string Email, int UserID)
        {
            bool exists = new Business().CheckEmailExists(Email,UserID);
            return Json(new { exists });
        }

    }

}