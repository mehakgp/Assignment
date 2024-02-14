-- Create Country table
CREATE TABLE Country (
    CountryID INT IDENTITY(1,1) PRIMARY KEY,
    CountryName NVARCHAR(100) NOT NULL
);

-- Create State table
CREATE TABLE State (
    StateID INT IDENTITY(1,1) PRIMARY KEY,
    StateName NVARCHAR(100) NOT NULL,
    CountryID INT,
    CONSTRAINT FK_CountryID FOREIGN KEY (CountryID) REFERENCES Country(CountryID)
);

-- Create UserDetails table
CREATE TABLE UserDetails (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    MiddleName NVARCHAR(50),
    LastName NVARCHAR(50) NOT NULL,
    Gender NVARCHAR(10),
    DateOfBirth DATE,
    AadharNo NVARCHAR(20) UNIQUE,
    Email NVARCHAR(100) UNIQUE,
    PhoneNumber NVARCHAR(20),
    Marks10th DECIMAL(5, 2),
    Board10th NVARCHAR(50),
    School10th NVARCHAR(100),
    YearOfCompletion10th DATE,
    Marks12th DECIMAL(5, 2),
    Board12th NVARCHAR(50),
    School12th NVARCHAR(100),
    YearOfCompletion12th DATE,
    CGPA DECIMAL(5, 2),
    University NVARCHAR(100),
    YearOfCompletionGraduation DATE,
    Hobbies NVARCHAR(MAX),
    Comments NVARCHAR(MAX)
);

-- Create AddressDetails table
CREATE TABLE AddressDetails (
    AddressID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT,
    AddressType INT,
    AddressLine1 NVARCHAR(100),
    AddressLine2 NVARCHAR(100),
    Pincode NVARCHAR(20),
    CountryID INT,
    StateID INT,
    CONSTRAINT FK_UserID FOREIGN KEY (UserID) REFERENCES UserDetails(UserID) ON DELETE CASCADE,
    CONSTRAINT CK_AddressType CHECK (AddressType IN (1, 2)),
	CONSTRAINT FKCountryID FOREIGN KEY (CountryID) REFERENCES Country(CountryID),
	CONSTRAINT FKStateID FOREIGN KEY (StateID) REFERENCES State(StateID)
);

-- Insert data into Country table
INSERT INTO Country (CountryName)
VALUES ('India'), ('China');

-- Insert data into State table for India
INSERT INTO State (StateName, CountryID)
VALUES ('IndiaState1', (SELECT CountryID FROM Country WHERE CountryName = 'India')),
       ('IndiaState2', (SELECT CountryID FROM Country WHERE CountryName = 'India'));

-- Insert data into State table for China
INSERT INTO State (StateName, CountryID)
VALUES ('ChinaState1', (SELECT CountryID FROM Country WHERE CountryName = 'China')),
       ('ChinaState2', (SELECT CountryID FROM Country WHERE CountryName = 'China'));

CREATE TABLE LogException (
    ExceptionID INT IDENTITY(1,1) PRIMARY KEY,
    LogTime DATETIME,
    ExceptionMessage NVARCHAR(MAX),
    StackTrace NVARCHAR(MAX)
);
CREATE TABLE Notes (
    ID INT PRIMARY KEY IDENTITY,
    ObjectID INT,
    ObjectType INT,
    Note NVARCHAR(MAX),
    DateTime DATETIME
);

SELECT * FROM Country;
SELECT * FROM State;
SELECT * FROM UserDetails;
SELECT * FROM AddressDetails;
SELECT * FROM Notes;

