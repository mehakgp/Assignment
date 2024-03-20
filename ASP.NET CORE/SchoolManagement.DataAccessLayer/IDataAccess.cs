using SchoolManagement.ModelView;

namespace SchoolManagement.DataAccessLayer
{
    public interface IDataAccess
    {
        public List<StudentModel> GetAllStudents();
        public List<TeacherModel> GetAllTeachers();

        public List<CourseModel> GetAllCourses();

        public bool AddStudent(StudentModel studentData);

        public bool AddTeacher(TeacherModel teacherData);

        public bool AddCourse(CourseModel courseData);

        public bool AddEnrollment(int studentId, int[] selectedCourseIds);
        public StudentDetailsModel GetStudentDetails(int studentId);
        public List<StudentModel> GetStudentsByCourse(int courseId);

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
