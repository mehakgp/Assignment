-- Create Student table
CREATE TABLE Student (
    StudentID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50)
);

-- Create Teacher table
CREATE TABLE Teacher (
    TeacherID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50)
);

-- Create Course table with cascading delete on Teacher
CREATE TABLE Course (
    CourseID INT PRIMARY KEY,
    CourseName VARCHAR(100),
    Credits INT,
    TeacherID INT,
    FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID) ON DELETE SET NULL
);

-- Create Enrollment table with cascading delete on Student and set null on Course
CREATE TABLE Enrollment (
    EnrollmentID INT PRIMARY KEY,
    StudentID INT,
    CourseID INT,
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID) ON DELETE CASCADE,
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID) ON DELETE SET NULL,
    CONSTRAINT UC_Enrollment UNIQUE (StudentID, CourseID)
);

-- Insert data into Student table
INSERT INTO Student (StudentID, FirstName, LastName)
VALUES
    (1, 'John', 'Doe'),
    (2, 'Jane', 'Smith'),
    (3, 'Alice', 'Johnson');

-- Insert data into Teacher table
INSERT INTO Teacher (TeacherID, FirstName, LastName)
VALUES
    (1, 'Professor', 'Anderson'),
    (2, 'Dr.', 'Miller'),
    (3, 'Ms.', 'Davis');

-- Insert data into Course table
INSERT INTO Course (CourseID, CourseName, Credits, TeacherID)
VALUES
    (101, 'Introduction to Computer Science', 3, 1),
    (102, 'Mathematics for Engineers', 4, 2),
    (103, 'Literature and Composition', 3, 3);

-- Insert data into Enrollment table
INSERT INTO Enrollment (EnrollmentID, StudentID, CourseID)
VALUES
    (1, 1, 101),
    (2, 1, 102),
    (3, 2, 101),
    (4, 3, 103);

-- Display the data in tables
SELECT * FROM Student;
SELECT * FROM Teacher;
SELECT * FROM Course;
SELECT * FROM Enrollment;
