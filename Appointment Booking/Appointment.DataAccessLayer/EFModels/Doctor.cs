using System;
using System.Collections.Generic;

namespace Appointment.DataAccessLayer.EFModels;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string DoctorName { get; set; } = null!;

    public int UserId { get; set; }

    public int? AppointmentSlotTime { get; set; }

    public TimeOnly DayStartTime { get; set; }

    public TimeOnly DayEndTime { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual User User { get; set; } = null!;
}
