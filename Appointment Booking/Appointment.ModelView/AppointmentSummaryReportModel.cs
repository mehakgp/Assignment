using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.ModelView
{
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
}
