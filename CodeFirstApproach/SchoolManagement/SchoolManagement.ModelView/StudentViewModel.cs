using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.ModelView
{
    public class StudentViewModel
    {
        public int? StudentId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please select at least one course.")]
        public int[] SelectedCourseIds { get; set; }
    }
}
