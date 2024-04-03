using Microsoft.AspNetCore.Mvc;
using SchoolManagement.BusinessLayer;
using SchoolManagement.ModelView;
using SchoolManagement.MVC.Models;
using System.Diagnostics;

namespace SchoolManagement.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBusiness _business;

        public HomeController(ILogger<HomeController> logger, IBusiness business)
        {
            _logger = logger;
            _business = business;
        }


        public IActionResult StudentList()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }

            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }
            List<StudentViewModel> students = _business.GetAllStudents();
            return View(students);
        }

        public IActionResult TeacherList()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }

            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }
            List<TeacherViewModel> teachers = _business.GetAllTeachers();
            return View(teachers);
        }

        public IActionResult CourseList()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }

            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }
            List<CourseViewModel> courses = _business.GetAllCourses();
            return View(courses);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
