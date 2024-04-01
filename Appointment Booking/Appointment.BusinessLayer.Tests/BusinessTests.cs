using Appointment.DataAccessLayer;
using Appointment.ModelView;
using Moq;

namespace Appointment.BusinessLayer.Tests
{
    public class BusinessTests
    {
        private Business _business;
        private Mock<IDataAccess> _dataAccessMock;

        [SetUp]
        public void Setup()
        {
            _dataAccessMock = new Mock<IDataAccess>();
            _business = new Business(_dataAccessMock.Object);
        }

        [Test]
        public async Task Register_ValidUser_ReturnsTrue()
        {
            // Arrange
            var newUser = new SignUpModel
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Password = "password123",
                DayStartTime = "09:00",
                DayEndTime = "17:00"
            };

            _dataAccessMock.Setup(x => x.Register(newUser, It.IsAny<TimeOnly>(), It.IsAny<TimeOnly>())).ReturnsAsync(true);

            // Act
            var result =await _business.Register(newUser);

            // Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void IsValidUser_ValidUser_ReturnsUserId()
        {
            // Arrange
            var user = new LogInModel { Email = "john.doe@example.com", Password = "password123" };
            _dataAccessMock.Setup(x => x.IsValidUser(user)).Returns(1);

            // Act
            var result = _business.IsValidUser(user);

            // Assert
            Assert.AreEqual(1, result);
        }
        [Test]
        public void IsEmailExists_ExistingEmail_ReturnsTrue()
        {
            // Arrange
            var email = "john.doe@example.com";
            _dataAccessMock.Setup(x => x.IsEmailExists(email)).Returns(true);

            // Act
            var result = _business.IsEmailExists(email);

            // Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void GetDoctors_ReturnsListOfDoctors()
        {
            // Arrange
            var doctors = new List<DoctorViewModel>
            {
                new DoctorViewModel { DoctorId = 1, DoctorName = "Dr. Smith" },
                new DoctorViewModel { DoctorId = 2, DoctorName = "Dr. Brown" }
            };
            _dataAccessMock.Setup(x => x.GetDoctors()).Returns(doctors);

            // Act
            var result = _business.GetDoctors();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public async Task BookAppointment_ValidAppointment_ReturnsTrue()
        {
            // Arrange
            var newAppointment = new AppointmentViewModel
            {
                AppointmentDate = new DateOnly(2024, 4, 1),
                AppointmentTime = new TimeOnly(9, 0, 0),
                DoctorId = 1,
                PatientName = "Alice",
                PatientEmail = "alice@example.com",
                PatientPhone = "1234567890",
                AppointmentStatus = "Open"
            };

            _dataAccessMock.Setup(x => x.BookAppointment(newAppointment)).ReturnsAsync(true);

            // Act
            var result =await _business.BookAppointment(newAppointment);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void GetTimeSlots_ReturnsListOfTimeSlots()
        {
            // Arrange
            int doctorId = 1;
            var appointmentDate = new DateOnly(2024, 4, 1);
            var timeSlots = new List<TimeOnly>
            {
                new TimeOnly(9, 0, 0),
                new TimeOnly(9, 30, 0),
                new TimeOnly(10, 0, 0)
            };

            _dataAccessMock.Setup(x => x.GetTimeSlots(doctorId, appointmentDate)).Returns(timeSlots);

            // Act
            var result = _business.GetTimeSlots(doctorId, appointmentDate);

            // Assert
            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public void GetListOfAppointments_ReturnsListOfAppointments()
        {
            int doctorId = 1;
            var selectedDate = new DateOnly(2024, 4, 1);
            var appointments = new List<AppointmentViewModel>
            {
                new AppointmentViewModel { AppointmentId = 1, AppointmentTime = new TimeOnly(9, 0, 0), PatientName = "Alice" },
                new AppointmentViewModel { AppointmentId = 2, AppointmentTime = new TimeOnly(10, 0, 0), PatientName = "Bob" }
            };

            _dataAccessMock.Setup(x => x.GetListOfAppointments(doctorId, selectedDate)).Returns(appointments);

            var result = _business.GetListOfAppointments(doctorId, selectedDate);

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public async Task CancelAppointment_ValidAppointmentId_ReturnsTrue()
        {
            // Arrange
            int appointmentId = 1;
            _dataAccessMock.Setup(x => x.CancelAppointment(appointmentId)).ReturnsAsync(true);

            // Act
            var result =await _business.CancelAppointment(appointmentId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task CloseAppointment_ValidAppointmentId_ReturnsTrue()
        {
            // Arrange
            int appointmentId = 1;
            _dataAccessMock.Setup(x => x.CloseAppointment(appointmentId)).ReturnsAsync(true);

            // Act
            var result =await _business.CloseAppointment(appointmentId);

            // Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void GetAppointmentSummaryReport_ReturnsListOfAppointmentSummaryReport()
        {
            // Arrange
            int doctorId = 1;
            int month = 4;
            int year = 2024;
            var report = new List<AppointmentSummaryReportModel>
            {
                new AppointmentSummaryReportModel { Date = new DateOnly(2024, 4, 1), NumberOfAppointments = 2, NumberOfAppointmentsClosed = 1, NumberOfAppointmentsCancelled = 1 },
                new AppointmentSummaryReportModel { Date = new DateOnly(2024, 4, 2), NumberOfAppointments = 1, NumberOfAppointmentsClosed = 1, NumberOfAppointmentsCancelled = 0 }
            };

            _dataAccessMock.Setup(x => x.GetAppointmentSummaryReport(doctorId, month, year)).Returns(report);

            // Act
            var result = _business.GetAppointmentSummaryReport(doctorId, month, year);

            // Assert
            Assert.AreEqual(2, result.Count);
        }
        [Test]
        public void GetAppointmentDetailedReport_ReturnsListOfAppointmentDetailedReport()
        {
            // Arrange
            int doctorId = 1;
            int month = 4;
            int year = 2024;
            var report = new List<AppointmentDetailedReportModel>
            {
                new AppointmentDetailedReportModel { Date = new DateOnly(2024, 4, 1), PatientName = "Alice", AppointmentStatus = "Closed" },
                new AppointmentDetailedReportModel { Date = new DateOnly(2024, 4, 2), PatientName = "Bob", AppointmentStatus = "Open" }
            };

            _dataAccessMock.Setup(x => x.GetAppointmentDetailedReport(doctorId, month, year)).Returns(report);

            // Act
            var result = _business.GetAppointmentDetailedReport(doctorId, month, year);

            // Assert
            Assert.AreEqual(2, result.Count);
        }
    }
}