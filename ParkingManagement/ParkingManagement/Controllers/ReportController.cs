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
    public class ReportController : Controller
    {
        public ActionResult ParkingZoneReport(DateTime? date)
        {
            if (!date.HasValue)
            {
                date = DateTime.Today;
            }

            List<ParkingZoneReportModel> report = new Business().GetParkingZoneReport(date.Value);

            return View(report);
        }
    }
}

