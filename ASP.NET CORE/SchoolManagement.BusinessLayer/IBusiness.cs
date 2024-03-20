using SchoolManagement.ModelView;

namespace SchoolManagement.BusinessLayer
{
    public interface IBusiness
    {
        public List<StudentModel> GetAllStudents();
        public List<TeacherModel> GetAllTeachers();
        public List<CourseModel> GetAllCourses();
        public bool AddStudent(StudentModel student);
        public bool AddTeacher(TeacherModel teacher);
        public bool AddCourse(CourseModel course);

        public StudentDetailsModel GetStudentDetails(int studentId);
        public TeacherDetailsModel GetTeacherDetails(int teacherId);

        public CourseDetailsModel GetCourseDetails(int courseId);

        public StudentModel GetStudent(int studentId);

        public TeacherModel GetTeacher(int teacherId);
        public CourseModel GetCourse(int courseId);
        public bool EditStudent(StudentModel student);
        public bool EditTeacher(TeacherModel teacher);
        public bool EditCourse(CourseModel course);

        public bool DeleteStudent(int studentId);
        public bool DeleteTeacher(int teacherId);
        public bool DeleteCourse(int courseId);
    }
}
