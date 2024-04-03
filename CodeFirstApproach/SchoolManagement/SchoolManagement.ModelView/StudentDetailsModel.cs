using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ModelView
{
    public class StudentDetailsModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<EnrollmentDetailsModel> Enrollments { get; set; }
    }
}
