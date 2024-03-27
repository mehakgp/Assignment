using Appointment.ModelView;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Appointment.MVC.Controllers
{
    public class ReportController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44362/api");
        private readonly HttpClient _client;

        public ReportController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult AppointmentSummaryReport(int month, int year)
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? -1;
            ViewBag.SelectedMonth=month;
            ViewBag.SelectedYear=year;

            string token = HttpContext.Request.Cookies["AuthToken"];
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/ReportAPI/GetAppointmentSummaryReport?doctorId={userId}&month={month}&year={year}").Result;

            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                List<AppointmentSummaryReportModel> report = JsonConvert.DeserializeObject<List<AppointmentSummaryReportModel>>(responseData);

                return View(report);
            }
            else
            {
                ViewBag.ErrorMessage = "Failed to retrieve appointments.";
                return View(new List<AppointmentSummaryReportModel>());
            }
          
        }

        public IActionResult AppointmentDetailedReport(int month, int year)
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? -1;
            ViewBag.SelectedMonth = month;
            ViewBag.SelectedYear = year;

            string token = HttpContext.Request.Cookies["AuthToken"];
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/ReportAPI/GetAppointmentDetailedReport?doctorId={userId}&month={month}&year={year}").Result;

            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                List<AppointmentDetailedReportModel> report = JsonConvert.DeserializeObject<List<AppointmentDetailedReportModel>>(responseData);

                return View(report);
            }
            else
            {
                ViewBag.ErrorMessage = "Failed to retrieve appointments.";
                return View(new List<AppointmentDetailedReportModel>());
            }

        }
    }
}
