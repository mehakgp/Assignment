using Microsoft.AspNetCore.Mvc;
using SchoolManagement.BusinessLayer;
using SchoolManagement.ModelView;

namespace SchoolManagement.Controllers
{
    public class DetailsController : Controller
    {
        private IBusiness _business;
        public DetailsController(IBusiness business)
        {
            _business = business;
        }

        public IActionResult DetailsStudent(int id)
        {
            StudentDetailsModel studentDetails = _business.GetStudentDetails(id);
            return View(studentDetails);
        }

        public IActionResult DetailsTeacher(int id)
        {
            TeacherDetailsModel teacherDetails = _business.GetTeacherDetails(id);
            return View(teacherDetails);
        }

        public IActionResult DetailsCourse(int id)
        {
            CourseDetailsModel courseDetails = _business.GetCourseDetails(id);
            return View(courseDetails);
        }
    }
}
