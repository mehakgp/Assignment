using Appointment.BusinessLayer;
using Appointment.ModelView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Appointment.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppointmentAPIController : ControllerBase
    {
        private IBusiness _business;

        public AppointmentAPIController(IBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            List<DoctorViewModel> doctors = _business.GetDoctors();
            return Ok(doctors);
        }

        [HttpPost]
        public IActionResult BookAppointment([FromBody] AppointmentViewModel newAppointment)
        {
            return Ok(_business.BookAppointment(newAppointment));
        }
        [HttpGet]
        public IActionResult GetTimeSlots(int doctorId, string appointmentDate)
        {
            DateTime parsedDate = DateTime.ParseExact(appointmentDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateOnly dateOnly = new DateOnly(parsedDate.Year, parsedDate.Month, parsedDate.Day);

            // Get time slots using the business layer
            List<TimeOnly> slots = _business.GetTimeSlots(doctorId, dateOnly);
            return Ok(slots);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetListOfAppointments(int id, string date)
        {
            DateTime parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateOnly dateOnly = new DateOnly(parsedDate.Year, parsedDate.Month, parsedDate.Day);
            List<AppointmentViewModel> listOfAppointments = _business.GetListOfAppointments(id, dateOnly);
            return Ok(listOfAppointments);
        }
        [HttpGet]
        [Authorize]
        public IActionResult CloseAppointment(int appointmentId)
        {
            return Ok(_business.CloseAppointment(appointmentId));
        }
        [HttpGet]
        [Authorize]
        public IActionResult CancelAppointment(int appointmentId)
        {
            return Ok(_business.CancelAppointment(appointmentId));
        }
    }
}
