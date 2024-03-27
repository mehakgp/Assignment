-- Create User table
CREATE TABLE [User] (
    UserId INT PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL
);

-- Create Doctor table
CREATE TABLE Doctor (
    DoctorId INT PRIMARY KEY,
    DoctorName VARCHAR(50) NOT NULL,
    UserId INT UNIQUE NOT NULL,
    AppointmentSlotTime INT, -- Assuming appointment slot time is in minutes
    DayStartTime TIME NOT NULL,
    DayEndTime TIME NOT NULL,
    FOREIGN KEY (UserId) REFERENCES [User](UserId)
);

-- Create Appointment table
CREATE TABLE Appointment (
    AppointmentId INT PRIMARY KEY,
    AppointmentDate DATE NOT NULL,
    AppointmentTime TIME NOT NULL,
    DoctorId INT NOT NULL,
    PatientName VARCHAR(50) NOT NULL,
    PatientEmail VARCHAR(255) NOT NULL,
    PatientPhone VARCHAR(255) NOT NULL,
    AppointmentStatus VARCHAR(20) NOT NULL CHECK (AppointmentStatus IN ('Open', 'Closed', 'Cancelled')),
    FOREIGN KEY (DoctorId) REFERENCES Doctor(DoctorId)
);
