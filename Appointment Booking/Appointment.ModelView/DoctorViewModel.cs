using System.ComponentModel.DataAnnotations;

namespace Appointment.ModelView
{
    public class DoctorViewModel
    {
        public int DoctorId { get; set; }

        public string DoctorName { get; set; } = null!;

        public int UserId { get; set; }

        public int? AppointmentSlotTime { get; set; }

        public TimeOnly DayStartTime { get; set; }

        public TimeOnly DayEndTime { get; set; }

    }
}
