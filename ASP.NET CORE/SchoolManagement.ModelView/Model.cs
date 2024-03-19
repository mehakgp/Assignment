using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.ModelView
{
    public class StudentModel
    {
        public int? StudentId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }

      [Required(ErrorMessage = "Please select at least one course.")]
        public int[] SelectedCourseIds { get; set; }
    }
    public class TeacherModel
    {
        public int? TeacherId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }

    public class CourseModel
    {
        public int? CourseId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Credits must be a positive integer")]
        public int Credits { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int? TeacherId { get; set; }
    }

    public class StudentDetailsModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<EnrollmentDetailsModel> Enrollments { get; set; }
    }

    public class EnrollmentDetailsModel
    {
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public TeacherModel Teacher { get; set; }
    }


    public class CoursesAndStudentsModel
    {

        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public List<StudentModel> Students { get; set; }
    }
    public class TeacherDetailsModel
    {
        public TeacherModel Teacher { get; set; }
        public List<CoursesAndStudentsModel> ListOfCoursesAndStudents { get; set; }
    }

    public class CourseDetailsModel
    {
        public CourseModel Course { get; set; }
        public TeacherModel Teacher { get; set; }
        public List<StudentModel> Students { get; set; }
    }
}
