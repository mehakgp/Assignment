using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CRUD_ENTITY_FRAMEWORK.ModelView.Model;
using static CRUD_ENTITY_FRAMEWORK.UtilityLayer.Utility;

namespace CRUD_ENTITY_FRAMEWORK.DataAccessLayer
{
    public class DataAccess
    {
        public static bool CreateStudent(StudentModel studentData)
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    var newStudent = new Student
                    {
                        FirstName = studentData.FirstName,
                        LastName = studentData.LastName
                    };
                    context.Students.Add(newStudent);

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }

        public static bool CreateTeacher(TeacherModel teacherData)
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    var newTeacher = new Teacher
                    {
                        FirstName = teacherData.FirstName,
                        LastName = teacherData.LastName
                    };
                    context.Teachers.Add(newTeacher);

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }

        public static bool CreateCourse(CourseModel courseData)
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    var newCourse = new Course
                    {
                        CourseName = courseData.CourseName,
                        Credits = courseData.Credits,
                        TeacherID = courseData.TeacherID
                    };
                    context.Courses.Add(newCourse);

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }

        public static bool CreateEnrollment(EnrollmentModel enrollmentData)
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    var newEnrollment = new Enrollment
                    {
                        StudentID = enrollmentData.StudentID,
                        CourseID = enrollmentData.CourseID
                    };
                    context.Enrollments.Add(newEnrollment);

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }




        public static List<StudentModel> GetAllStudents()
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    var allStudents = context.Students.ToList();
                    return allStudents.Select(student => new StudentModel
                    {
                        StudentID = student.StudentID,
                        FirstName = student.FirstName,
                        LastName = student.LastName
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return new List<StudentModel>();
            }
        }

        public static List<TeacherModel> GetAllTeachers()
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    var allTeachers = context.Teachers.ToList();
                    return allTeachers.Select(teacher => new TeacherModel
                    {
                        TeacherID = teacher.TeacherID,
                        FirstName = teacher.FirstName,
                        LastName = teacher.LastName
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return new List<TeacherModel>();
            }
        }

        public static List<CourseModel> GetAllCourses()
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    var allCourses = context.Courses.ToList();
                    return allCourses.Select(course => new CourseModel
                    {
                        CourseID = course.CourseID,
                        CourseName = course.CourseName,
                        Credits = (int)course.Credits,
                        TeacherID = (int)course.TeacherID
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return new List<CourseModel>();
            }
        }

        public static List<EnrollmentModel> GetAllEnrollments()
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    var allEnrollments = context.Enrollments.ToList();
                    return allEnrollments.Select(enrollment => new EnrollmentModel
                    {
                        EnrollmentID = enrollment.EnrollmentID,
                        StudentID = (int)enrollment.StudentID,
                        CourseID = (int)enrollment.CourseID
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return new List<EnrollmentModel>();
            }
        }

        public static List<StudentModel> GetStudentsByCourse(int courseId)
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    var studentsInCourse = (from enrollment in context.Enrollments
                                            where enrollment.CourseID == courseId
                                            select enrollment.Student).ToList();

                    return studentsInCourse.Select(student => new StudentModel
                    {
                        StudentID = student.StudentID,
                        FirstName = student.FirstName,
                        LastName = student.LastName
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return new List<StudentModel>();
            }
        }
       
        public static List<CourseModel> GetCoursesByStudent(int studentId)
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    var coursesByStudent = (from enrollment in context.Enrollments
                                            where enrollment.StudentID == studentId
                                            select enrollment.Course).ToList();

                    return coursesByStudent.Select(course => new CourseModel
                    {
                        CourseID = course.CourseID,
                        CourseName = course.CourseName,
                        Credits = (int)course.Credits,
                        TeacherID = (int)course.TeacherID
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return new List<CourseModel>();
            }
        }


        public static bool UpdateStudent(StudentModel studentData, int studentID)
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    var studentToUpdate = context.Students.Find(studentID);

                    if (studentToUpdate != null)
                    {
                        studentToUpdate.FirstName = studentData.FirstName;
                        studentToUpdate.LastName = studentData.LastName;

                        return context.SaveChanges() > 0;
                    }
                    else
                    {
                        Console.WriteLine($"Student with ID {studentID} not found.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }

        public static bool UpdateTeacher(TeacherModel teacherData, int teacherID)
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    var teacherToUpdate = context.Teachers.Find(teacherID);

                    if (teacherToUpdate != null)
                    {
                        teacherToUpdate.FirstName = teacherData.FirstName;
                        teacherToUpdate.LastName = teacherData.LastName;

                        return context.SaveChanges() > 0;
                    }
                    else
                    {
                        Console.WriteLine($"Teacher with ID {teacherID} not found.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }

        public static bool UpdateCourse(CourseModel courseData, int courseID)
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    var courseToUpdate = context.Courses.Find(courseID);

                    if (courseToUpdate != null)
                    {
                        courseToUpdate.CourseName = courseData.CourseName;
                        courseToUpdate.Credits = courseData.Credits;

                        return context.SaveChanges() > 0;
                    }
                    else
                    {
                        Console.WriteLine($"Course with ID {courseID} not found.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }

        public static bool UpdateEnrollment(EnrollmentModel enrollmentData, int enrollmentID)
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    var enrollmentToUpdate = context.Enrollments.Find(enrollmentID);

                    if (enrollmentToUpdate != null)
                    {
                        enrollmentToUpdate.StudentID = enrollmentData.StudentID;
                        enrollmentToUpdate.CourseID = enrollmentData.CourseID;

                        return context.SaveChanges() > 0;
                    }
                    else
                    {
                        Console.WriteLine($"Enrollment with ID {enrollmentID} not found.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }



        public static bool DeleteStudent(int studentID)
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    var studentToDelete = context.Students.Find(studentID);

                    if (studentToDelete != null)
                    {
                        context.Students.Remove(studentToDelete);
                        return context.SaveChanges() > 0;
                    }
                    else
                    {
                        Console.WriteLine($"Student with ID {studentID} not found.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }

        public static bool DeleteTeacher(int teacherID)
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    var teacherToDelete = context.Teachers.Find(teacherID);

                    if (teacherToDelete != null)
                    {
                        context.Teachers.Remove(teacherToDelete);
                        return context.SaveChanges() > 0;
                    }
                    else
                    {
                        Console.WriteLine($"Teacher with ID {teacherID} not found.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }

        public static bool DeleteCourse(int courseID)
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    var courseToDelete = context.Courses.Find(courseID);

                    if (courseToDelete != null)
                    {
                        context.Courses.Remove(courseToDelete);
                        return context.SaveChanges() > 0;
                    }
                    else
                    {
                        Console.WriteLine($"Course with ID {courseID} not found.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }

        public static bool DeleteEnrollment(int enrollmentID)
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    var enrollmentToDelete = context.Enrollments.Find(enrollmentID);

                    if (enrollmentToDelete != null)
                    {
                        context.Enrollments.Remove(enrollmentToDelete);
                        return context.SaveChanges() > 0;
                    }
                    else
                    {
                        Console.WriteLine($"Enrollment with ID {enrollmentID} not found.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }


    }

}
