using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CRUD_ENTITY_FRAMEWORK.UtilityLayer.Utility;
using System.IO;
using CRUD_ENTITY_FRAMEWORK.DataAccessLayer;
using static CRUD_ENTITY_FRAMEWORK.ModelView.Model;

namespace CRUD_ENTITY_FRAMEWORK.BusinessLayer
{
    public class Business
    {

       
        public static bool CreateStudent(StudentModel studentData)
        {
            return DataAccess.CreateStudent(studentData);
        }
       
        public static bool CreateTeacher(TeacherModel teacherData)
        {
            return DataAccess.CreateTeacher(teacherData);
        }

        public static bool CreateCourse(CourseModel courseData)
        {
            return DataAccess.CreateCourse(courseData);
        }

        public static bool CreateEnrollment(EnrollmentModel enrollmentData)
        {
            return DataAccess.CreateEnrollment(enrollmentData);
        }


        public static List<StudentModel> GetAllStudents()
        {
            return DataAccess.GetAllStudents();
        }

        public static List<TeacherModel> GetAllTeachers()
        {
            return DataAccess.GetAllTeachers();
        }

        public static List<CourseModel> GetAllCourses()
        {
            return DataAccess.GetAllCourses();
        }

        public static List<EnrollmentModel> GetAllEnrollments()
        {
            return DataAccess.GetAllEnrollments();
        }

        public static List<StudentModel> GetStudentsByCourse(int courseId)
        {
            return DataAccess.GetStudentsByCourse(courseId);
        }

        public static List<CourseModel> GetCoursesByStudent(int studentId)
        {
            return DataAccess.GetCoursesByStudent(studentId);
        }


        public static bool UpdateStudent(StudentModel studentData, int studentID)
        {
            return DataAccess.UpdateStudent(studentData, studentID);
        }

        public static bool UpdateTeacher(TeacherModel teacherData, int teacherID)
        {
            return DataAccess.UpdateTeacher(teacherData, teacherID);
        }

        public static bool UpdateCourse(CourseModel courseData, int courseID)
        {
            return DataAccess.UpdateCourse(courseData, courseID);
        }

        public static bool UpdateEnrollment(EnrollmentModel enrollmentData, int enrollmentID)
        {
            return DataAccess.UpdateEnrollment(enrollmentData, enrollmentID);
        }


        public static bool DeleteStudent(int studentID)
        {
            return DataAccess.DeleteStudent(studentID);
        }

        public static bool DeleteTeacher(int teacherID)
        {
            return DataAccess.DeleteTeacher(teacherID);
        }

        public static bool DeleteCourse(int courseID)
        {
            return DataAccess.DeleteCourse(courseID);
        }

        public static bool DeleteEnrollment(int enrollmentID)
        {
            return DataAccess.DeleteEnrollment(enrollmentID);
        }

        public static List<object> GetAllDataForEntity(EntityChoice entityChoice)
        {
            switch (entityChoice)
            {
                case EntityChoice.Student:
                    return GetAllStudents().Cast<object>().ToList();
                case EntityChoice.Teacher:
                    return GetAllTeachers().Cast<object>().ToList();
                case EntityChoice.Course:
                    return GetAllCourses().Cast<object>().ToList();
                case EntityChoice.Enrollment:
                    return GetAllEnrollments().Cast<object>().ToList();
                default:
                    return new List<object>();
            }
        }

    }
}
