using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ModelView
{
    public class TeacherDetailsModel
    {
        public TeacherViewModel Teacher { get; set; }
        public List<CoursesAndStudentsModel> ListOfCoursesAndStudents { get; set; }
    }
}
