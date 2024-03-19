using System;
using System.Collections.Generic;

namespace SchoolManagement.DataAccessLayer.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; }

    public int Credits { get; set; }

    public int? TeacherId { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Teacher? Teacher { get; set; }
}
