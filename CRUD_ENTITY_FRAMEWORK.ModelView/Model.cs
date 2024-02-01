using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ENTITY_FRAMEWORK.ModelView
{
    public class Model
    {
        public class StudentModel
        {
            public int StudentID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class TeacherModel
        {
            public int TeacherID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class CourseModel
        {
            public int CourseID { get; set; }
            public string CourseName { get; set; }
            public int Credits { get; set; }
            public int TeacherID { get; set; }
        }
        public class EnrollmentModel
        {
            public int EnrollmentID { get; set; }
            public int StudentID { get; set; }
            public int CourseID { get; set; }
        }
    }
}
