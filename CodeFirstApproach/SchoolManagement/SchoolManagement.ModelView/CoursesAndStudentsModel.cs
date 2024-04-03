using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ModelView
{
    public class CoursesAndStudentsModel
    {

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public List<StudentViewModel> Students { get; set; }
    }
}
