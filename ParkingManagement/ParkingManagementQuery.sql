CREATE TABLE "User" (
    UserId INT PRIMARY KEY IDENTITY (1,1),
    Name NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Type NVARCHAR(50) NOT NULL
);

CREATE TABLE ParkingZone (
    ParkingZoneId INT PRIMARY KEY IDENTITY (1,1) ,
    ParkingZoneTitle NVARCHAR(255) NOT NULL
);

CREATE TABLE ParkingSpace (
    ParkingSpaceId INT PRIMARY KEY IDENTITY (1,1),
    ParkingSpaceTitle NVARCHAR(255) NOT NULL,
    ParkingZoneId INT NOT NULL,
    FOREIGN KEY (ParkingZoneId) REFERENCES ParkingZone(ParkingZoneId)
);

CREATE TABLE VehicleParking (
    VehicleParkingId INT PRIMARY KEY IDENTITY (1,1),
    ParkingZoneId INT NOT NULL,
    ParkingSpaceId INT NOT NULL,
    BookingDateTime DATETIME,
    ReleaseDateTime DATETIME,
    VehicleRegistrationNumber NVARCHAR(50) NOT NULL,
    FOREIGN KEY (ParkingZoneId) REFERENCES ParkingZone(ParkingZoneId),
    FOREIGN KEY (ParkingSpaceId) REFERENCES ParkingSpace(ParkingSpaceId)
);
-- Add Parking Zones
INSERT INTO ParkingZone (ParkingZoneId, ParkingZoneTitle) VALUES (1, 'A');
INSERT INTO ParkingZone (ParkingZoneId, ParkingZoneTitle) VALUES (2, 'B');
INSERT INTO ParkingZone (ParkingZoneId, ParkingZoneTitle) VALUES (3, 'C');

