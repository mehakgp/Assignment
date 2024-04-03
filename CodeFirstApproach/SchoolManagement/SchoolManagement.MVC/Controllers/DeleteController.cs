using Microsoft.AspNetCore.Mvc;
using SchoolManagement.BusinessLayer;

namespace SchoolManagement.MVC.Controllers
{
    public class DeleteController : Controller
    {
        private IBusiness _business;
        public DeleteController(IBusiness business)
        {
            _business = business;
        }

        [HttpPost]
        public IActionResult DeleteStudent(int id)
        {
            if (_business.DeleteStudent(id))
            {
                TempData["SuccessMessage"] = "Student deletion successful.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete student. Please try again.";
            }
            return RedirectToAction("StudentList", "Home");
        }
        [HttpPost]
        public IActionResult DeleteTeacher(int id)
        {
            if (_business.DeleteTeacher(id))
            {
                TempData["SuccessMessage"] = "Teacher deletion successful.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete Teacher. Please try again.";
            }
            return RedirectToAction("TeacherList", "Home");
        }
        [HttpPost]
        public IActionResult DeleteCourse(int id)
        {
            if (_business.DeleteCourse(id))
            {
                TempData["SuccessMessage"] = "Course deletion successful.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete course. Please try again.";
            }
            return RedirectToAction("CourseList", "Home");
        }
    }
}
