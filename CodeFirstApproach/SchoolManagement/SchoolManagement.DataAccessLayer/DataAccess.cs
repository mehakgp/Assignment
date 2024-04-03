using SchoolManagement.DataAccessLayer.Models;
using SchoolManagement.ExceptionHandling;
using SchoolManagement.ModelView;

namespace SchoolManagement.DataAccessLayer
{

    public class DataAccess : IDataAccess
    {
        private readonly SchoolDbContext _context;
        private readonly ExceptionHandler _exceptionHandler;
        public DataAccess(SchoolDbContext context, ExceptionHandler exceptionHandler)
        {
            _context = context;
            _exceptionHandler = exceptionHandler;
        }

        public List<StudentViewModel> GetAllStudents()
        {
            try
            {
                var allStudents = _context.Students.ToList();
                return allStudents.Select(student => new StudentViewModel
                {
                    StudentId = student.StudentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName
                }).ToList();
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return new List<StudentViewModel>();
            }
        }

        public List<TeacherViewModel> GetAllTeachers()
        {
            try
            {
                var allTeachers = _context.Teachers.ToList();
                return allTeachers.Select(teacher => new TeacherViewModel
                {
                    TeacherId = teacher.TeacherId,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName
                }).ToList();

            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return new List<TeacherViewModel>();
            }
        }

        public List<CourseViewModel> GetAllCourses()
        {
            try
            {
                var allCourses = _context.Courses.ToList();
                return allCourses.Select(course => new CourseViewModel
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName,
                    Credits = course.Credits,
                }).ToList();
            }

            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return new List<CourseViewModel>();
            }
        }

        public bool AddStudent(StudentViewModel studentData)
        {
            try
            {

                var newStudent = new Student
                {
                    FirstName = studentData.FirstName,
                    LastName = studentData.LastName
                };
                _context.Students.Add(newStudent);
                _context.SaveChanges();
                return AddEnrollment(newStudent.StudentId, studentData.SelectedCourseIds);
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return false;
            }
        }

        public bool AddTeacher(TeacherViewModel teacherData)
        {
            try
            {
                var newTeacher = new Teacher
                {
                    FirstName = teacherData.FirstName,
                    LastName = teacherData.LastName
                };
                _context.Teachers.Add(newTeacher);

                return _context.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return false;
            }
        }

        public bool AddCourse(CourseViewModel courseData)
        {
            try
            {
                var newCourse = new Course
                {
                    CourseName = courseData.CourseName,
                    Credits = courseData.Credits,
                    TeacherId = courseData.TeacherId
                };
                _context.Courses.Add(newCourse);

                return _context.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return false;
            }
        }

        public bool AddEnrollment(int studentId, int[] selectedCourseIds)
        {
            try
            {
                var existingEnrollments = _context.Enrollments.Where(e => e.StudentId == studentId);
                _context.Enrollments.RemoveRange(existingEnrollments);
                foreach (var courseId in selectedCourseIds)
                {
                    _context.Enrollments.Add(new Enrollment { StudentId = studentId, CourseId = courseId });
                }
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return false;
            }
        }
        public StudentDetailsModel GetStudentDetails(int studentId)
        {
            try
            {
                var student = _context.Students.Find(studentId);
                if (student == null)
                {
                    return null;
                }

                var enrollments = _context.Enrollments
                    .Where(e => e.StudentId == studentId)
                    .Select(e => new EnrollmentDetailsModel
                    {
                        CourseName = e.Course.CourseName,
                        Credits = e.Course.Credits,
                        Teacher = new TeacherViewModel
                        {
                            FirstName = e.Course.Teacher.FirstName,
                            LastName = e.Course.Teacher.LastName
                        }
                    }).ToList();

                var studentDetails = new StudentDetailsModel
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Enrollments = enrollments
                };
                return studentDetails;
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return null;
            }
        }
        public List<StudentViewModel> GetStudentsByCourse(int courseId)
        {
            try
            {
                var studentsInCourse = (from enrollment in _context.Enrollments
                                        where enrollment.CourseId == courseId
                                        select enrollment.Student).ToList();

                return studentsInCourse.Select(student => new StudentViewModel
                {
                    StudentId = student.StudentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName
                }).ToList();

            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return new List<StudentViewModel>();
            }
        }

        public TeacherDetailsModel GetTeacherDetails(int teacherId)
        {
            try
            {
                var teacher = _context.Teachers.Find(teacherId);
                if (teacher == null)
                {
                    return null;
                }
                else
                {
                    TeacherViewModel TeacherViewModel = new TeacherViewModel { FirstName = teacher.FirstName, LastName = teacher.LastName };
                    var coursesTaughtByTeacher = (from course in _context.Courses
                                                  where course.TeacherId == teacherId
                                                  select course).ToList();

                    var listOfCoursesAndStudents = new List<CoursesAndStudentsModel>();

                    foreach (var course in coursesTaughtByTeacher)
                    {
                        List<StudentViewModel> studentsInCourse = GetStudentsByCourse(course.CourseId);

                        CoursesAndStudentsModel coursesAndStudentsModel = new CoursesAndStudentsModel
                        {
                            CourseId = course.CourseId,
                            CourseName = course.CourseName,
                            Credits = (int)course.Credits,
                            Students = studentsInCourse
                        };

                        listOfCoursesAndStudents.Add(coursesAndStudentsModel);
                    }
                    var teacherDetailsModel = new TeacherDetailsModel
                    {
                        Teacher = TeacherViewModel,
                        ListOfCoursesAndStudents = listOfCoursesAndStudents

                    };

                    return teacherDetailsModel;
                }
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return new TeacherDetailsModel();
            }
        }

        public CourseDetailsModel GetCourseDetails(int courseId)
        {
            try
            {
                var course = _context.Courses.Find(courseId);
                if (course == null)
                {
                    return null;
                }
                else
                {
                    var teacher = _context.Teachers.FirstOrDefault(t => t.TeacherId == course.TeacherId);
                    CourseViewModel CourseViewModel = new CourseViewModel { CourseName = course.CourseName, Credits = course.Credits };
                    TeacherViewModel TeacherViewModel = new TeacherViewModel { FirstName = teacher.FirstName, LastName = teacher.LastName };
                    return new CourseDetailsModel
                    {
                        Course = CourseViewModel,
                        Teacher = TeacherViewModel,
                        Students = GetStudentsByCourse(courseId)
                    };
                }
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return new CourseDetailsModel();
            }
        }

        public StudentViewModel GetStudent(int studentId)
        {
            try
            {
                var student = _context.Students.FirstOrDefault(s => s.StudentId == studentId);
                if (student != null)
                {
                    return new StudentViewModel
                    {
                        StudentId = student.StudentId,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        SelectedCourseIds = _context.Enrollments.Where(e => e.StudentId == studentId).Select(e => e.CourseId).ToArray(),
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return null;
            }
        }
        public TeacherViewModel GetTeacher(int teacherId)
        {
            try
            {
                var teacher = _context.Teachers.FirstOrDefault(t => t.TeacherId == teacherId);
                if (teacher != null)
                {
                    return new TeacherViewModel
                    {
                        TeacherId = teacher.TeacherId,
                        FirstName = teacher.FirstName,
                        LastName = teacher.LastName
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return null;
            }
        }
        public CourseViewModel GetCourse(int courseId)
        {
            try
            {
                var course = _context.Courses.FirstOrDefault(c => c.CourseId == courseId);
                if (course != null)
                {
                    return new CourseViewModel
                    {
                        CourseId = course.CourseId,
                        CourseName = course.CourseName,
                        Credits = course.Credits,
                        TeacherId = course.TeacherId
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return null;
            }
        }

        public bool EditStudent(StudentViewModel student)
        {
            try
            {
                var studentToUpdate = _context.Students.Find(student.StudentId);

                if (studentToUpdate != null)
                {
                    studentToUpdate.FirstName = student.FirstName;
                    studentToUpdate.LastName = student.LastName;
                    _context.SaveChanges();
                    return AddEnrollment((int)student.StudentId, student.SelectedCourseIds);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return false;
            }
        }

        public bool EditTeacher(TeacherViewModel teacher)
        {
            try
            {
                var teacherToUpdate = _context.Teachers.Find(teacher.TeacherId);

                if (teacherToUpdate != null)
                {
                    teacherToUpdate.FirstName = teacher.FirstName;
                    teacherToUpdate.LastName = teacher.LastName;

                    return _context.SaveChanges() > 0;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return false;
            }
        }

        public bool EditCourse(CourseViewModel course)
        {
            try
            {
                var courseToUpdate = _context.Courses.Find(course.CourseId);

                if (courseToUpdate != null)
                {
                    courseToUpdate.CourseName = course.CourseName;
                    courseToUpdate.Credits = course.Credits;
                    courseToUpdate.TeacherId = course.TeacherId;
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return false;
            }
        }

        public bool DeleteStudent(int studentId)
        {
            try
            {
                var studentToDelete = _context.Students.Find(studentId);

                if (studentToDelete != null)
                {
                    _context.Students.Remove(studentToDelete);
                    return _context.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return false;
            }
        }

        public bool DeleteTeacher(int teacherId)
        {
            try
            {
                var teacherToDelete = _context.Teachers.Find(teacherId);

                if (teacherToDelete != null)
                {
                    _context.Teachers.Remove(teacherToDelete);
                    return _context.SaveChanges() > 0;
                }
                return false;

            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return false;
            }
        }

        public bool DeleteCourse(int courseId)
        {
            try
            {
                var courseToDelete = _context.Courses.Find(courseId);

                if (courseToDelete != null)
                {
                    _context.Courses.Remove(courseToDelete);
                    return _context.SaveChanges() > 0;
                }
                return false;

            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return false;
            }
        }
    }


}
