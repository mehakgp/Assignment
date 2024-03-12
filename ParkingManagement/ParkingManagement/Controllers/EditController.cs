using ParkingManagement.BusinessLayer;
using ParkingManagement.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkingManagement.Controllers
{
    [CustomAuthenticationFilter]
    [CustomAuthorizationFilter]
    public class EditController : Controller
    {
        List<ParkingZoneModel> listOfParkingZone = new Business().GetParkingZones();
        public ActionResult EditParkingSpace()
        {
            ViewBag.ListOfParkingZone = listOfParkingZone;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditParkingSpace(AddParkingSpaceModel editParkingSpace)
        {
            if (ModelState.IsValid)
            {
                if (new Business().EditParkingSpace(editParkingSpace))
                {
                    ViewBag.SuccessMessage = "Parking Space edited successfully";
                }
                else
                {
                    ViewBag.ErrorMessage = "Failed to edit parking space. Please try again.";
                }
            }
            ViewBag.ListOfParkingZone = listOfParkingZone;
            return View(editParkingSpace);
        }

    }
}