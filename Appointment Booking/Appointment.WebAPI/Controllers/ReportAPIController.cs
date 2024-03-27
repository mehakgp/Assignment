using Appointment.BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportAPIController : ControllerBase
    {
        private IBusiness _business;

        public ReportAPIController(IBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAppointmentSummaryReport(int doctorId, int month, int year)
        {
           return Ok(_business.GetAppointmentSummaryReport(doctorId, month, year));
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetAppointmentDetailedReport(int doctorId, int month, int year)
        {
            return Ok(_business.GetAppointmentDetailedReport(doctorId, month, year));
        }
    }
}
