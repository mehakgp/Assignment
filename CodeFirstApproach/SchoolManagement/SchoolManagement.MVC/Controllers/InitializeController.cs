using Microsoft.AspNetCore.Mvc;
using SchoolManagement.BusinessLayer;
using SchoolManagement.ModelView;

namespace SchoolManagement.MVC.Controllers
{
    public class InitializeController : Controller
    {
        private IBusiness _business;
        private List<CourseViewModel> listOfCourses;
        private List<TeacherViewModel> listOfTeachers;
        public InitializeController(IBusiness business)
        {
            _business = business;
            listOfCourses = _business.GetAllCourses();
            listOfTeachers = _business.GetAllTeachers();
        }

        [HttpGet]
        public IActionResult StudentForm(int? id)
        {
            ViewBag.ListOfCourses = listOfCourses;
            if (id == null)
            {
                return View();
            }
            else
            {
                StudentViewModel student = _business.GetStudent((int)id);
                return View(student);
            }

        }
        [HttpPost]
        public IActionResult StudentForm(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                if (student.StudentId == null)
                {

                    if (_business.AddStudent(student))
                    {
                        ViewBag.SuccessMessage = "Student added successfully";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Failed to add Student. Please try again.";
                    }
                }
                else
                {
                    if (_business.EditStudent(student))
                    {
                        ViewBag.SuccessMessage = "Student details edited successfully";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Failed to edit student details. Please try again.";
                    }
                }

            }
            ViewBag.ListOfCourses = listOfCourses;
            return View(student);
        }

        [HttpGet]
        public IActionResult TeacherForm(int? id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                TeacherViewModel TeacherViewModel = _business.GetTeacher((int)id);
                return View(TeacherViewModel);
            }

        }

        [HttpPost]
        public IActionResult TeacherForm(TeacherViewModel teacher)
        {
            if (ModelState.IsValid)
            {
                if (teacher.TeacherId == null)
                {
                    if (_business.AddTeacher(teacher))
                    {
                        ViewBag.SuccessMessage = "Teacher added successfully";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Failed to add Teacher. Please try again.";
                    }
                }
                else
                {
                    if (_business.EditTeacher(teacher))
                    {
                        ViewBag.SuccessMessage = "Teacher details edited successfully";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Failed to edit teacher details. Please try again.";
                    }
                }
            }
            return View(teacher);
        }

        [HttpGet]
        public IActionResult CourseForm(int? id)
        {
            ViewBag.ListOfTeachers = listOfTeachers;
            if (id == null)
            {
                return View();
            }
            else
            {
                CourseViewModel CourseViewModel = _business.GetCourse((int)id);
                return View(CourseViewModel);
            }
        }

        [HttpPost]
        public IActionResult CourseForm(CourseViewModel course)
        {
            if (ModelState.IsValid)
            {
                if (course.CourseId == null)
                {
                    if (_business.AddCourse(course))
                    {
                        ViewBag.SuccessMessage = "Course added successfully";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Failed to add Course. Please try again.";
                    }
                }
                else
                {
                    if (_business.EditCourse(course))
                    {
                        ViewBag.SuccessMessage = "Course details edited successfully";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Failed to edit course details. Please try again.";
                    }
                }

            }
            ViewBag.ListOfTeachers = listOfTeachers;
            return View(course);
        }
    }
}
