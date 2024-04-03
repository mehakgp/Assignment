using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ModelView
{
    public class CourseDetailsModel
    {
        public CourseViewModel Course { get; set; }
        public TeacherViewModel Teacher { get; set; }
        public List<StudentViewModel> Students { get; set; }
    }
}
