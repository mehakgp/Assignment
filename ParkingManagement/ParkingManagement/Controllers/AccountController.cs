using ParkingManagement.ModelView;
using System.Web.Mvc;
using ParkingManagement.BusinessLayer;

namespace ParkingManagement.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult SignUp()
        {
            return View();
        }
    

        [HttpPost]
        public ActionResult SignUp(UserModel model)
        {
            if (ModelState.IsValid)
            {
                if (new Business().SaveUser(model))
                {
                    TempData["SuccessMessage"] = "User signed up successfully!";
                    return RedirectToAction("LogIn", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Error occurred while saving user. Please try again.";
                }
            }

            return View(model);
        }

        public JsonResult CheckEmailExists(string email)
        {
            bool exists = new Business().IsEmailExists(email);
            return Json(new { exists = exists }, JsonRequestBehavior.AllowGet);
        }
    }
}