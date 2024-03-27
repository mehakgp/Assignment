using System.ComponentModel.DataAnnotations;
using System.Numerics;

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



    public class AppointmentViewModel
    {
        public int? AppointmentId { get; set; }

        [Display(Name = "Appointment Date")]
        [Required(ErrorMessage = "Please enter the appointment date.")]
        public DateOnly AppointmentDate { get; set; }

        [Display(Name = "Appointment Time")]
        [Required(ErrorMessage = "Please select the appointment time.")]
        public TimeOnly AppointmentTime { get; set; }

        [Display(Name = "Doctor")]
        [Required(ErrorMessage = "Please select a doctor.")]
        public int DoctorId { get; set; }

        [Display(Name = "Patient Name")]
        [Required(ErrorMessage = "Please enter the patient's name.")]
        public string PatientName { get; set; } = null!;

        [Display(Name = "Patient Email")]
        [Required(ErrorMessage = "Please enter the patient's email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string PatientEmail { get; set; } = null!;

        [Display(Name = "Patient Phone")]
        [Required(ErrorMessage = "Please enter the patient's phone number.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string PatientPhone { get; set; } = null!;
        [Display(Name = "Appointment Status")]
        public string AppointmentStatus { get; set; } = "Open";
    }



    public class SignUpModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }

        [Display(Name = "Appointment Slot Time")]
        [Range(1, 60, ErrorMessage = "Appointment slot time must be between 1 and 60")]
        public int? AppointmentSlotTime { get; set; }

        [Required(ErrorMessage = "DayStartTime is required")]
        public string DayStartTime { get; set; }

        [Required(ErrorMessage = "DayEndTime is required")]
        public string DayEndTime { get; set; }
    }

    public class LogInModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }
    }

    public class AppointmentSummaryReportModel
    {
        [Display(Name = "Date")]
        public DateOnly Date { get; set; }
        [Display(Name = "Number Of Appointments")]
        public int NumberOfAppointments { get; set; }
        [Display(Name = "Number Of Appointments Closed")]
        public int NumberOfAppointmentsClosed { get; set; }

        [Display(Name = "Number Of Appointments Cancelled")]
        public int NumberOfAppointmentsCancelled { get; set; }
    }
    public class AppointmentDetailedReportModel
    {
        [Display(Name = "Date")]
        public DateOnly Date { get; set; }

        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        [Display(Name = "Appointment Status")]
        public string AppointmentStatus { get; set; }
    }
}
