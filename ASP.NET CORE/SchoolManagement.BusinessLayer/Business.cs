using SchoolManagement.DataAccessLayer;
using SchoolManagement.ModelView;

namespace SchoolManagement.BusinessLayer
{
    public class Business:IBusiness
    {
        private readonly IDataAccess _dataAccess;

        public Business(IDataAccess dataAccess)
        {
            _dataAccess=dataAccess;
        }


        public List<StudentModel> GetAllStudents()
        {
            return _dataAccess.GetAllStudents();
        }
        public List<TeacherModel> GetAllTeachers()
        {
            return _dataAccess.GetAllTeachers();
        }
        public List<CourseModel> GetAllCourses()
        {
            return _dataAccess.GetAllCourses();
        }
        public bool AddStudent(StudentModel student)
        {
            return _dataAccess.AddStudent(student);
        }
        public bool AddTeacher(TeacherModel teacher)
        {
            return _dataAccess.AddTeacher(teacher);
        }
        public   bool AddCourse(CourseModel course)
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

        public StudentModel GetStudent(int studentId)
        {
            return _dataAccess.GetStudent(studentId);
        }

        public TeacherModel GetTeacher(int teacherId)
        {
            return _dataAccess.GetTeacher(teacherId);
        }
        public CourseModel GetCourse(int courseId)
        {
            return _dataAccess.GetCourse(courseId);
        }
        public bool EditStudent(StudentModel student)
        {
            return _dataAccess.EditStudent(student);
        }
        public bool EditTeacher(TeacherModel teacher)
        {
            return _dataAccess.EditTeacher(teacher);
        }
        public  bool EditCourse(CourseModel course)
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
