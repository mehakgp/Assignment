using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ModelView
{
    public class CourseViewModel
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
}
