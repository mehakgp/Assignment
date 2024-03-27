using Appointment.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using System.Text;
namespace Appointment.MVC.Controllers
{
    public class AppointmentController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44362/api");
        private readonly HttpClient _client;

        List<DoctorViewModel> doctorsList;
        public AppointmentController()
        {
            doctorsList = new List<DoctorViewModel>();
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }


        [HttpGet]
        public IActionResult BookAppointment()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/AppointmentAPI/GetDoctors").Result;
            if (response.IsSuccessStatusCode)
            {
                doctorsList = response.Content.ReadAsAsync<List<DoctorViewModel>>().Result;
                ViewBag.Doctors = new SelectList(doctorsList, "DoctorId", "DoctorName");
            }
            return View();
        }

        [HttpPost]
        public IActionResult BookAppointment(AppointmentViewModel newAppointment)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(newAppointment);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/AppointmentAPI/BookAppointment", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;
                    bool isBooked = JsonConvert.DeserializeObject<bool>(responseData);
                    if (isBooked)
                    {
                        TempData["SuccessMessage"] = "Appointment Booked Successfully !";
                        return RedirectToAction("BookAppointment");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Error occurred while booking appointment. Please try again.";
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Error occurred while calling the API. Please try again.";
                }
            }
            HttpResponseMessage result = _client.GetAsync(_client.BaseAddress + "/AppointmentAPI/GetDoctors").Result;
            if (result.IsSuccessStatusCode)
            {
                doctorsList = result.Content.ReadAsAsync<List<DoctorViewModel>>().Result;
                ViewBag.Doctors = new SelectList(doctorsList, "DoctorId", "DoctorName");
            }
            return View(newAppointment);
        }
        [HttpGet]
        public IActionResult GetTimeSlots(int doctorId, DateOnly appointmentDate)
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/AppointmentAPI/GetTimeSlots?doctorId={doctorId}&appointmentDate={appointmentDate}").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                return Content(responseData, "application/json");
            }
            else
            {
                return BadRequest("Failed to fetch time slots.");
            }
        }

        [HttpGet]
        public IActionResult AppointmentList(DateOnly? date)
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }
            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }

            int userId = HttpContext.Session.GetInt32("UserId") ?? -1;
            DateOnly selectedDate = date ?? DateOnly.FromDateTime(DateTime.Today);
            ViewBag.SelectedDate = selectedDate;

            string token = HttpContext.Request.Cookies["AuthToken"];
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);


            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/AppointmentAPI/GetListOfAppointments?id={userId}&date={selectedDate}").Result;

            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                List<AppointmentViewModel> appointments = JsonConvert.DeserializeObject<List<AppointmentViewModel>>(responseData);

                return View(appointments);
            }
            else
            {
                ViewBag.ErrorMessage = "Failed to retrieve appointments.";
                return View(new List<AppointmentViewModel>());
            }
        }

        [HttpPost]
        public IActionResult CloseAppointment(int appointmentId ,DateOnly selectedDate)
        {
            string token = HttpContext.Request.Cookies["AuthToken"];
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/AppointmentAPI/CloseAppointment?appointmentId={appointmentId}").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                bool success = JsonConvert.DeserializeObject<bool>(responseData);
                if (success)
                {
                    TempData["SuccessMessage"] = "Appointment Closed successfully!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error occurred while closing appointment. Please try again.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Error occurred while calling the API. Please try again.";
            }
            return RedirectToAction("AppointmentList", new { date = selectedDate });

        }

        [HttpPost]
        public IActionResult CancelAppointment(int appointmentId, DateOnly selectedDate)
        {
            string token = HttpContext.Request.Cookies["AuthToken"];
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/AppointmentAPI/CancelAppointment?appointmentId={appointmentId}").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                bool success = JsonConvert.DeserializeObject<bool>(responseData);
                if (success)
                {
                    TempData["SuccessMessage"] = "Appointment Cancelled successfully!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error occurred while cancelling appointment. Please try again.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Error occurred while calling the API. Please try again.";
            }
            return RedirectToAction("AppointmentList", new { date = selectedDate });
        }


    }
}
