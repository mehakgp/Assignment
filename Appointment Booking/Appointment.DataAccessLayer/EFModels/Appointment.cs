using System;
using System.Collections.Generic;

namespace Appointment.DataAccessLayer.EFModels;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public DateOnly AppointmentDate { get; set; }

    public TimeOnly AppointmentTime { get; set; }

    public int DoctorId { get; set; }

    public string PatientName { get; set; } = null!;

    public string PatientEmail { get; set; } = null!;

    public string PatientPhone { get; set; } = null!;

    public string AppointmentStatus { get; set; } = null!;

    public virtual Doctor Doctor { get; set; } = null!;
}
