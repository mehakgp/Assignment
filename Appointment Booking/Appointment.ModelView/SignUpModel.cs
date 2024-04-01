using System.ComponentModel.DataAnnotations;

namespace Appointment.ModelView
{
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
}
