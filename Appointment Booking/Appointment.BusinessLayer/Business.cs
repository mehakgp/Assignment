using Appointment.DataAccessLayer;
using Appointment.ModelView;
using System.Globalization;

namespace Appointment.BusinessLayer
{
    public class Business : IBusiness
    {

        private readonly IDataAccess _dataAccess;

        public Business(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<bool> Register(SignUpModel newUser)
        {
            TimeOnly startTime = TimeOnly.ParseExact(newUser.DayStartTime, "HH:mm", CultureInfo.InvariantCulture);
            TimeOnly endTime = TimeOnly.ParseExact(newUser.DayEndTime, "HH:mm", CultureInfo.InvariantCulture);

            return _dataAccess.Register(newUser, startTime, endTime);
        }
        public int IsValidUser(LogInModel user)
        {
            return _dataAccess.IsValidUser(user);
        }
        public bool IsEmailExists(string email)
        {
            return _dataAccess.IsEmailExists(email);
        }
        public List<DoctorViewModel> GetDoctors()
        {
            return _dataAccess.GetDoctors();
        }
        public Task<bool> BookAppointment(AppointmentViewModel newAppointment)
        {
            return _dataAccess.BookAppointment(newAppointment);
        }

        public List<TimeOnly> GetTimeSlots(int doctorId, DateOnly appointmentDate)
        {

            return _dataAccess.GetTimeSlots(doctorId, appointmentDate);

        }
        public List<AppointmentViewModel> GetListOfAppointments(int doctorId,DateOnly selectedDate)
        {
           return  _dataAccess.GetListOfAppointments(doctorId, selectedDate);
        }

        public Task<bool> CancelAppointment(int appointmentId)
        {
            return _dataAccess.CancelAppointment(appointmentId);
        }
        public Task<bool> CloseAppointment(int appointmentId)
        {
            return _dataAccess.CloseAppointment(appointmentId);
        }
        public List<AppointmentSummaryReportModel> GetAppointmentSummaryReport(int doctorId, int month, int year)
        {
            return _dataAccess.GetAppointmentSummaryReport(doctorId,month, year);
        }
        public List<AppointmentDetailedReportModel> GetAppointmentDetailedReport(int doctorId, int month, int year)
        {
            return _dataAccess.GetAppointmentDetailedReport(doctorId, month, year);
        }
    }
}