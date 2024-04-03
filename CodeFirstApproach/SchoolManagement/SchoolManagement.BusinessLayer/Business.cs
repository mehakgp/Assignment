using SchoolManagement.DataAccessLayer;
using SchoolManagement.ModelView;

namespace SchoolManagement.BusinessLayer
{
    public class Business : IBusiness
    {
        private readonly IDataAccess _dataAccess;

        public Business(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }


        public List<StudentViewModel> GetAllStudents()
        {
            return _dataAccess.GetAllStudents();
        }
        public List<TeacherViewModel> GetAllTeachers()
        {
            return _dataAccess.GetAllTeachers();
        }
        public List<CourseViewModel> GetAllCourses()
        {
            return _dataAccess.GetAllCourses();
        }
        public bool AddStudent(StudentViewModel student)
        {
            return _dataAccess.AddStudent(student);
        }
        public bool AddTeacher(TeacherViewModel teacher)
        {
            return _dataAccess.AddTeacher(teacher);
        }
        public bool AddCourse(CourseViewModel course)
        {
            return _dataAccess.AddCourse(course);
        }

        public StudentDetailsModel GetStudentDetails(int studentId)
        {
            return _dataAccess.GetStudentDetails(studentId);
        }
        public TeacherDetailsModel GetTeacherDetails(int teacherId)
        {
            return _dataAccess.GetTeacherDetails(teacherId);
        }

        public CourseDetailsModel GetCourseDetails(int courseId)
        {
            return _dataAccess.GetCourseDetails(courseId);
        }

        public StudentViewModel GetStudent(int studentId)
        {
            return _dataAccess.GetStudent(studentId);
        }

        public TeacherViewModel GetTeacher(int teacherId)
        {
            return _dataAccess.GetTeacher(teacherId);
        }
        public CourseViewModel GetCourse(int courseId)
        {
            return _dataAccess.GetCourse(courseId);
        }
        public bool EditStudent(StudentViewModel student)
        {
            return _dataAccess.EditStudent(student);
        }
        public bool EditTeacher(TeacherViewModel teacher)
        {
            return _dataAccess.EditTeacher(teacher);
        }
        public bool EditCourse(CourseViewModel course)
        {
            return _dataAccess.EditCourse(course);
        }
        public bool DeleteStudent(int studentId)
        {
            return _dataAccess.DeleteStudent(studentId);
        }
        public bool DeleteTeacher(int teacherId)
        {
            return _dataAccess.DeleteTeacher(teacherId);
        }
        public bool DeleteCourse(int courseId)
        {
            return _dataAccess.DeleteCourse(courseId);
        }
    }
}
