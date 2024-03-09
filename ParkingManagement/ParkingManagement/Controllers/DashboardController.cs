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
    public class DashboardController : Controller
    {
        public ActionResult Index(int[] selectedZoneIds)
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }

            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }
            if (TempData["SelectedZoneIds"] != null)
            {
                selectedZoneIds = TempData["SelectedZoneIds"] as int[];
            }

            List<ParkingZoneModel> parkingZones = new Business().GetParkingZones();

            if (selectedZoneIds == null || selectedZoneIds.Length == 0)
            {
                selectedZoneIds = new int[] { (int)(parkingZones.FirstOrDefault()?.ParkingZoneId) };
            }
            List<ParkingSpaceModel> parkingSpaces = new Business().GetParkingSpacesForZones(selectedZoneIds);

            var viewModel = new ParkingSpaceListViewModel
            {
                ParkingSpaces = parkingSpaces,
                ParkingZones = parkingZones,
                SelectedZoneIds = selectedZoneIds
            };

            return View(viewModel);
        }

        [HttpPost]
        [CustomAuthorizationFilter]
        public ActionResult BookParkingSpace(int parkingSpaceId, string vehicleRegistrationNumber, int[] selectedZoneIds)
        {
            if (new Business().BookParkingSpace(parkingSpaceId, vehicleRegistrationNumber))
            {
                TempData["SuccessMessage"] = "Parking space booked successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to book parking space. Please try again.";
            }
            TempData["SelectedZoneIds"] = selectedZoneIds;
            return RedirectToAction("Index");
        }

        [HttpPost]
        [CustomAuthorizationFilter]
        public ActionResult ReleaseParkingSpace(int parkingSpaceId, string vehicleRegistrationNumber, int[] selectedZoneIds)
        {

            if (new Business().ReleaseParkingSpace(parkingSpaceId, vehicleRegistrationNumber))
            {
                TempData["SuccessMessage"] = "Parking space released successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to release parking space. Please try again.";
            }
            TempData["SelectedZoneIds"] = selectedZoneIds;
            return RedirectToAction("Index");
        }

        [HttpPost]
        [CustomAuthorizationFilter]
        public ActionResult ReleaseAllParkingSpace(int[] selectedZoneIds)
        {
            if (new Business().ReleaseAllParkingSpace())
            {
                TempData["SuccessMessage"] = "All parking space released successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to release all parking space. Please try again.";
            }
            TempData["SelectedZoneIds"] = selectedZoneIds;
            return RedirectToAction("Index");
        }

    }
}
