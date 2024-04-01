namespace Appointment.UtilityLayer
{
    public class Utility
    {
        public static int UserId { get; set; } = -1;

        public enum AppointmentStatus
        {
            Open,Cancelled,Closed
        }
    }
}
