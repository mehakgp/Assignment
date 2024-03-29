﻿using Appointment.DataAccessLayer.EFModels;
using Appointment.ModelView;
using SchoolManagement.ExceptionHandling;
namespace Appointment.DataAccessLayer
{
    public class DataAccess : IDataAccess
    {
        private readonly AppointmentBookingDbContext _context;
        private readonly ExceptionHandler _exceptionHandler;
        public DataAccess(AppointmentBookingDbContext context, ExceptionHandler exceptionHandler)
        {
            _context = context;
            _exceptionHandler = exceptionHandler;
        }

        public bool Register(SignUpModel newUser, TimeOnly startTime, TimeOnly endTime)
        {
            try
            {
                var user = new User { Name = newUser.Name, Email = newUser.Email, Password = newUser.Password };
                _context.Users.Add(user);
                int success = _context.SaveChanges();
                if (success != 0)
                {
                    _context.Doctors.Add(new Doctor { DoctorName = newUser.Name, UserId = user.UserId, AppointmentSlotTime = newUser.AppointmentSlotTime, DayEndTime = endTime, DayStartTime = startTime });
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return false;
            }
        }

        public int IsValidUser(LogInModel user)
        {
            try
            {
                var validUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
                if (validUser != null && validUser.Password == user.Password)
                {
                    return validUser.UserId;

                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return -1;
            }
        }
        public bool IsEmailExists(string email)
        {
            try
            {
                return _context.Users.Any(u => u.Email == email);
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return false;
            }
        }

        public List<DoctorViewModel> GetDoctors()
        {
            try
            {
                return _context.Doctors.Select(d => new DoctorViewModel
                {
                    DoctorId = d.DoctorId,
                    DoctorName = d.DoctorName,
                }).ToList();
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return new List<DoctorViewModel>();
            }
        }

        public bool BookAppointment(AppointmentViewModel newAppointment)
        {
            try
            {
                _context.Appointments.Add(new EFModels.Appointment
                {
                    AppointmentDate = newAppointment.AppointmentDate,
                    AppointmentTime = newAppointment.AppointmentTime,
                    DoctorId = newAppointment.DoctorId,
                    PatientName = newAppointment.PatientName,
                    PatientEmail = newAppointment.PatientEmail,
                    PatientPhone = newAppointment.PatientPhone,
                    AppointmentStatus = newAppointment.AppointmentStatus
                    //AppointmentStatus =Utility.AppointmentStatus.Open.ToString()
                });
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return false;
            }
        }
        public List<TimeOnly> GetTimeSlots(int doctorId, DateOnly appointmentDate)
        {
            try
            {
                var slots = new List<TimeOnly>();
                var doctor = _context.Doctors.FirstOrDefault(d => d.DoctorId == doctorId);
                if (doctor != null)
                {


                    var startTime = doctor.DayStartTime;
                    var endTime = doctor.DayEndTime;
                    var slotTime = doctor.AppointmentSlotTime;

                    var currentTime = startTime;
                    while (currentTime < endTime)
                    {
                        slots.Add(currentTime);
                        currentTime = currentTime.AddMinutes((double)slotTime);
                    }

                    var bookedSlots = _context.Appointments
                  .Where(a => a.DoctorId == doctorId && a.AppointmentDate == appointmentDate)
                  .Select(a => a.AppointmentTime)
                  .ToList();

                    slots = slots.Except(bookedSlots).ToList();
                }
                return slots;
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return new List<TimeOnly>();
            }
        }

        public List<AppointmentViewModel> GetListOfAppointments(int doctorId, DateOnly selectedDate)
        {
            try
            {
                return _context.Appointments
             .Where(appointment => appointment.DoctorId == doctorId && appointment.AppointmentDate == selectedDate)
             .Select(appointment => new AppointmentViewModel
             {
                 AppointmentId = appointment.AppointmentId,
                 AppointmentTime = appointment.AppointmentTime,
                 PatientName = appointment.PatientName,
                 PatientEmail = appointment.PatientEmail,
                 PatientPhone = appointment.PatientPhone,
                 AppointmentStatus = appointment.AppointmentStatus
             })
             .ToList();
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return new List<AppointmentViewModel>();
            }

        }

        public bool CancelAppointment(int appointmentId)
        {
            try
            {
                var appointment = _context.Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
                if (appointment != null)
                {
                    appointment.AppointmentStatus = "Cancelled";
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return false;
            }
        }
        public bool CloseAppointment(int appointmentId)
        {
            try
            {
                var appointment = _context.Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
                if (appointment != null)
                {
                    appointment.AppointmentStatus = "Closed";
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return false;
            }
        }

        public List<AppointmentSummaryReportModel> GetAppointmentSummaryReport(int doctorId, int month, int year)
        {
            try
            {
                var startDate = new DateOnly(year, month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                var appointments = _context.Appointments
                    .Where(a => a.DoctorId == doctorId &&
                                a.AppointmentDate >= startDate &&
                                a.AppointmentDate <= endDate)
                    .ToList();


                var report = appointments
                    .GroupBy(a => a.AppointmentDate)
                    .Select(g => new AppointmentSummaryReportModel
                    {
                        Date = g.Key,
                        NumberOfAppointments = g.Count(),
                        NumberOfAppointmentsClosed = g.Count(a => a.AppointmentStatus == "Closed"),
                        NumberOfAppointmentsCancelled = g.Count(a => a.AppointmentStatus == "Cancelled")
                    })
                    .ToList();

                return report;

            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return new List<AppointmentSummaryReportModel>();
            }
        }
        public List<AppointmentDetailedReportModel> GetAppointmentDetailedReport(int doctorId, int month, int year)
        {
            try
            {
                var startDate = new DateOnly(year, month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                var appointments = _context.Appointments
                    .Where(a => a.DoctorId == doctorId &&
                                a.AppointmentDate >= startDate &&
                                a.AppointmentDate <= endDate)
                    .OrderBy(a => a.AppointmentDate)
                    .Select(a => new AppointmentDetailedReportModel
                    {
                        Date = a.AppointmentDate,
                        PatientName = a.PatientName,
                        AppointmentStatus = a.AppointmentStatus
                    })
                    .ToList();

                return appointments;
            }
            catch (Exception ex)
            {
                _exceptionHandler.LogException(ex);
                return new List<AppointmentDetailedReportModel>();
            }
        }

    }
}