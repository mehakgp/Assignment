using Appointment.ModelView;
using Appointment.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using Appointment.UtilityLayer;

namespace Appointment.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        Uri baseAddress = new Uri("https://localhost:44362/api");
        private readonly HttpClient _client;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
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
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/HomeAPI/IsValidUser", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<dynamic>(responseData);
                    int userId = result.userId;
                    string token = result.token;

                    if (userId != -1)
                    {
                        Utility.UserId = userId;
                        HttpContext.Session.SetInt32("UserId", userId);
                        HttpContext.Response.Cookies.Append("AuthToken", token);
                        return RedirectToAction("AppointmentList", "Appointment");
                    }

                    else
                    {
                        ViewBag.ErrorMessage = "Invalid Email or Password.";
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Error occurred while calling the API. Please try again.";
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            Utility.UserId = -1;
            HttpContext.Session.Remove("UserId");
            HttpContext.Response.Cookies.Delete("AuthToken");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/HomeAPI/Register", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;
                    bool isRegistered = JsonConvert.DeserializeObject<bool>(responseData);
                    if (isRegistered)
                    {
                        TempData["SuccessMessage"] = "User Registered successfully!";
                        return RedirectToAction("LogIn");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Error occurred while saving user. Please try again.";
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Error occurred while calling the API. Please try again.";
                }
            }

            return View(model);
        }

        public JsonResult CheckEmailExists(string email)
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/HomeAPI/IsEmailExists?email={email}").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                bool exists = JsonConvert.DeserializeObject<bool>(responseData);
                return Json(new { exists = exists });
            }
            else
            {
                return Json(new { exists = true });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
