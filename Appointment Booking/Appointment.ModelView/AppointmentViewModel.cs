using System.ComponentModel.DataAnnotations;

namespace Appointment.ModelView
{

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

        [Display(Name = "Patient's Name")]
        [Required(ErrorMessage = "Please enter the patient's name.")]
        public string PatientName { get; set; } = null!;

        [Display(Name = "Patient's Email Address")]
        [Required(ErrorMessage = "Please enter the patient's email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string PatientEmail { get; set; } = null!;

        [Display(Name = "Patient's Phone Number")]
        [Required(ErrorMessage = "Please enter the patient's phone number.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string PatientPhone { get; set; } = null!;
        [Display(Name = "Appointment Status")]
        public string AppointmentStatus { get; set; } = UtilityLayer.Utility.AppointmentStatus.Open.ToString(); /* "Open"*/
    }

}
