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
    public class HomeController : Controller
    {
        //logIn
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool success = new Business().LogIn(model);
                if (success)
                {
                    SessionModel modelSessionInfo = GetUserSessionInfo();
                    if (modelSessionInfo.IsAdmin)
                    {
                        return RedirectToAction("UserList", "Users");
                    }
                    else
                    {
                        return RedirectToAction("UserDetailsForm", "UserDetails", new { id = modelSessionInfo.UserID });
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or password.");
                }

            }
            return View(model);

        }

        public ActionResult LogOut()
        {
            System.Web.HttpContext.Current.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}