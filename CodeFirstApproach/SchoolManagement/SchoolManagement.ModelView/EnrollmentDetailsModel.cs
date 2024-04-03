using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ModelView
{
    public class EnrollmentDetailsModel
    {
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public TeacherViewModel Teacher { get; set; }
    }
}
