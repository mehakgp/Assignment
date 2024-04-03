using SchoolManagement.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLayer
{
    public interface IBusiness
    {
        public List<StudentViewModel> GetAllStudents();
        public List<TeacherViewModel> GetAllTeachers();
        public List<CourseViewModel> GetAllCourses();
        public bool AddStudent(StudentViewModel student);
        public bool AddTeacher(TeacherViewModel teacher);
        public bool AddCourse(CourseViewModel course);

        public StudentDetailsModel GetStudentDetails(int studentId);
        public TeacherDetailsModel GetTeacherDetails(int teacherId);

        public CourseDetailsModel GetCourseDetails(int courseId);

        public StudentViewModel GetStudent(int studentId);

        public TeacherViewModel GetTeacher(int teacherId);
        public CourseViewModel GetCourse(int courseId);
        public bool EditStudent(StudentViewModel student);
        public bool EditTeacher(TeacherViewModel teacher);
        public bool EditCourse(CourseViewModel course);

        public bool DeleteStudent(int studentId);
        public bool DeleteTeacher(int teacherId);
        public bool DeleteCourse(int courseId);

    }
}
