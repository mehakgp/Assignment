using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ParkingManagement.BusinessLayer;
using ParkingManagement.ModelView;

namespace ParkingManagement.Controllers
{
    [CustomAuthenticationFilter]
    [CustomAuthorizationFilter]
    public class InitializeController : Controller
    {

        List<ParkingZoneModel> listOfParkingZone = new Business().GetParkingZones();

        public ActionResult AddParkingZone()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddParkingZone(AddParkingZoneModel newParkingZone)
        {
            if (ModelState.IsValid)
            {
                if (new Business().AddParkingZone(newParkingZone))
                {
                    ViewBag.SuccessMessage = "Parking Zone added successfully";
                }
                else
                {
                    ViewBag.ErrorMessage = "Failed to add parking zone. Please try again.";
                }

            }

            return View(newParkingZone);
        }

     
        public ActionResult AddParkingSpace()
        {
            ViewBag.ListOfParkingZone= listOfParkingZone;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddParkingSpace(AddParkingSpaceModel newParkingSpace)
        {
            if (ModelState.IsValid)
            {
                if (new Business().AddParkingSpace(newParkingSpace))
                {
                    ViewBag.SuccessMessage = "Parking Space added successfully";
                }
                else
                {
                    ViewBag.ErrorMessage = "Failed to add parking space. Please try again.";
                }
            }
            ViewBag.ListOfParkingZone = listOfParkingZone;
            return View(newParkingSpace);
        }

        public JsonResult IsParkingZoneTitleExists(string parkingZoneTitle)
        {
            bool isExists = new Business().IsParkingZoneTitleExists(parkingZoneTitle);
            return Json(isExists, JsonRequestBehavior.AllowGet);
        }
    }
}