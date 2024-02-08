CREATE TABLE Student (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50)
);

CREATE TABLE Teacher (
    TeacherID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50)
);

CREATE TABLE Course (
    CourseID INT IDENTITY(100,1) PRIMARY KEY,
    CourseName VARCHAR(100),
    Credits INT,
    TeacherID INT,
    FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID) ON DELETE SET NULL
);
CREATE TABLE Enrollment (
    EnrollmentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT,
    CourseID INT,
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID) ON DELETE CASCADE,
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID) ON DELETE CASCADE,
    CONSTRAINT UC_Enrollment UNIQUE (StudentID, CourseID)
);

INSERT INTO Student (FirstName, LastName)
VALUES
    ('John', 'Doe'),
    ('Jane', 'Smith'),
    ('Alice', 'Johnson');

INSERT INTO Teacher (FirstName, LastName)
VALUES
    ('Professor', 'Anderson'),
    ('Dr.', 'Miller'),
    ('Ms.', 'Davis');

INSERT INTO Course (CourseName, Credits, TeacherID)
VALUES
    ('Introduction to Computer Science', 3, 1),
    ('Mathematics for Engineers', 4, 2),
    ('Literature and Composition', 3, 3),
	('Machine Learning', 3, 1);

INSERT INTO Enrollment (StudentID, CourseID)
VALUES
    (1, 100),
    (1, 102),
    (2, 101),
    (3, 102);

SELECT * FROM Student;
SELECT * FROM Teacher;
SELECT * FROM Course;
SELECT * FROM Enrollment;

CREATE TABLE LogException (
    ExceptionID INT IDENTITY(1,1) PRIMARY KEY,
    LogTime DATETIME,
    ExceptionMessage NVARCHAR(MAX),
    StackTrace NVARCHAR(MAX)
);
 SELECT *FROM LogException;

