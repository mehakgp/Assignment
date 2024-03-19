using SchoolManagement.DataAccessLayer.Models;
using SchoolManagement.ModelView;
using SchoolManagement.ExceptionHandling;

namespace SchoolManagement.DataAccessLayer

{
    public class DataAccess : IDataAccess
    {
        private readonly SchoolDbContext _context;

        public DataAccess(SchoolDbContext context)
        {
            _context = context;
        }

        public List<StudentModel> GetAllStudents()
        {
            try
            {
                var allStudents = _context.Students.ToList();
                return allStudents.Select(student => new StudentModel
                {
                    StudentId = student.StudentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName
                }).ToList();
            }
            catch (Exception ex)
            {
                //log exception
                return new List<StudentModel>();
            }
        }

        public List<TeacherModel> GetAllTeachers()
        {
            try
            {
                var allTeachers = _context.Teachers.ToList();
                return allTeachers.Select(teacher => new TeacherModel
                {
                    TeacherId = teacher.TeacherId,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName
                }).ToList();

            }
            catch (Exception ex)
            {
                //  LogException(ex);
                return new List<TeacherModel>();
            }
        }

        public List<CourseModel> GetAllCourses()
        {
            try
            {
                var allCourses = _context.Courses.ToList();
                return allCourses.Select(course => new CourseModel
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName,
                    Credits = course.Credits,
                }).ToList();
            }

            catch (Exception ex)
            {
                //LogException(ex);
                return new List<CourseModel>();
            }
        }

        public bool AddStudent(StudentModel studentData)
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
                //    LogException(ex);
                return false;
            }
        }

        public bool AddTeacher(TeacherModel teacherData)
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
                //  LogException(ex);
                return false;
            }
        }

        public bool AddCourse(CourseModel courseData)
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
                // LogException(ex);
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
                // LogException(ex);
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
                        Teacher = new TeacherModel
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
                //  LogException(ex);
                return null;
            }
        }
        public List<StudentModel> GetStudentsByCourse(int courseId)
        {
            try
            {
                var studentsInCourse = (from enrollment in _context.Enrollments
                                        where enrollment.CourseId == courseId
                                        select enrollment.Student).ToList();

                return studentsInCourse.Select(student => new StudentModel
                {
                    StudentId = student.StudentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName
                }).ToList();

            }
            catch (Exception ex)
            {
                // LogException(ex);
                return new List<StudentModel>();
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
                    TeacherModel teacherModel = new TeacherModel { FirstName = teacher.FirstName, LastName = teacher.LastName };
                    var coursesTaughtByTeacher = (from course in _context.Courses
                                                  where course.TeacherId == teacherId
                                                  select course).ToList();

                    var listOfCoursesAndStudents = new List<CoursesAndStudentsModel>();

                    foreach (var course in coursesTaughtByTeacher)
                    {
                        List<StudentModel> studentsInCourse = GetStudentsByCourse(course.CourseId);

                        CoursesAndStudentsModel coursesAndStudentsModel = new CoursesAndStudentsModel
                        {
                            CourseID = course.CourseId,
                            CourseName = course.CourseName,
                            Credits = (int)course.Credits,
                            Students = studentsInCourse
                        };

                        listOfCoursesAndStudents.Add(coursesAndStudentsModel);
                    }
                    var teacherDetailsModel = new TeacherDetailsModel
                    {
                        Teacher = teacherModel,
                        ListOfCoursesAndStudents = listOfCoursesAndStudents

                    };

                    return teacherDetailsModel;
                }
            }
            catch (Exception ex)
            {
                // LogException(ex);
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
                    CourseModel courseModel = new CourseModel { CourseName = course.CourseName, Credits = course.Credits };
                    TeacherModel teacherModel = new TeacherModel { FirstName = teacher.FirstName, LastName = teacher.LastName };
                    return new CourseDetailsModel
                    {
                        Course = courseModel,
                        Teacher = teacherModel,
                        Students = GetStudentsByCourse(courseId)
                    };
                }
            }
            catch (Exception ex)
            {
                // LogException(ex);
                return new CourseDetailsModel();
            }
        }

        public StudentModel GetStudent(int studentId)
        {
            try
            {
                var student = _context.Students.FirstOrDefault(s => s.StudentId == studentId);
                if (student != null)
                {
                    return new StudentModel
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
                // LogException(ex);
                return null;
            }
        }
        public TeacherModel GetTeacher(int teacherId)
        {
            try
            {
                var teacher = _context.Teachers.FirstOrDefault(t => t.TeacherId == teacherId);
                if (teacher != null)
                {
                    return new TeacherModel
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
                // LogException(ex);
                return null;
            }
        }
        public CourseModel GetCourse(int courseId)
        {
            try
            {
                var course = _context.Courses.FirstOrDefault(c => c.CourseId == courseId);
                if (course != null)
                {
                    return new CourseModel
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
                // LogException(ex);
                return null;
            }
        }

        public bool EditStudent(StudentModel student)
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
                // LogException(ex);
                return false;
            }
        }

        public bool EditTeacher(TeacherModel teacher)
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
                //   LogException(ex);
                return false;
            }
        }

        public bool EditCourse(CourseModel course)
        {
            try
            {
                    var courseToUpdate = _context.Courses.Find(course.CourseId);

                    if (courseToUpdate != null)
                    {
                        courseToUpdate.CourseName = course.CourseName;
                        courseToUpdate.Credits = course.Credits;
                        courseToUpdate.TeacherId = course.TeacherId;

                        return _context.SaveChanges() > 0;
                    }
                    else
                    {
                        return false;
                    }
            }
            catch (Exception ex)
            {
                //LogException(ex);
                return false;
            }
        }

    }
}
