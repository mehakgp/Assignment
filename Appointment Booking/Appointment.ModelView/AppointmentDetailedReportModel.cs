using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.ModelView
{
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
