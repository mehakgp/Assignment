using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkingManagement.BusinessLayer;
using ParkingManagement.ModelView;

namespace ParkingManagement.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult LogIn()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogInModel model)
        {
            if (ModelState.IsValid)
            {
                if (IsValidUser(model.Email, model.Password))
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid Email or Password.";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public bool IsValidUser(string email, string password)
        {
           return new Business().IsValidUser(email, password);
        }

        public ActionResult LogOut()
        {
            if (System.Web.HttpContext.Current != null)
            {
                System.Web.HttpContext.Current.Session.Clear();
            }
            return RedirectToAction("LogIn", "Home");
        }
    }
}