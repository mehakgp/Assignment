using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ENTITY_FRAMEWORK
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose CRUD operation:");
                Console.WriteLine("1. Create");
                Console.WriteLine("2. Read");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Delete");
                Console.WriteLine("5. Exit");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            CreateOperation();
                            break;
                        case 2:
                            ReadOperation();
                            break;
                        case 3:
                            UpdateOperation();
                            break;
                        case 4:
                            DeleteOperation();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        static void CreateOperation()
        {
            using (var context = new CRUD_DBEntities())
            {
                Console.WriteLine("Choose entity to create:");
                Console.WriteLine("1. Student");
                Console.WriteLine("2. Teacher");
                Console.WriteLine("3. Course");

                if (int.TryParse(Console.ReadLine(), out int entityChoice))
                {
                    switch (entityChoice)
                    {
                        case 1:
                            Console.Write("Enter student's first name: ");
                            string firstNameStudent = Console.ReadLine();

                            Console.Write("Enter student's last name: ");
                            string lastNameStudent = Console.ReadLine();

                            var newStudent = new Student
                            {
                                FirstName = firstNameStudent,
                                LastName = lastNameStudent
                            };

                            context.Students.Add(newStudent);
                            break;

                        case 2:
                            Console.Write("Enter teacher's first name: ");
                            string firstNameTeacher = Console.ReadLine();

                            Console.Write("Enter teacher's last name: ");
                            string lastNameTeacher = Console.ReadLine();

                            var newTeacher = new Teacher
                            {
                                FirstName = firstNameTeacher,
                                LastName = lastNameTeacher
                            };

                            context.Teachers.Add(newTeacher);
                            break;

                        case 3:
                            Console.Write("Enter course name: ");
                            string courseName = Console.ReadLine();

                            Console.Write("Enter credits: ");
                            int credits;
                            if (int.TryParse(Console.ReadLine(), out credits))
                            {
                                var newCourse = new Course
                                {
                                    CourseName = courseName,
                                    Credits = credits
                                };

                                context.Courses.Add(newCourse);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for credits.");
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                            break;
                    }

                    // Save changes to the database
                    context.SaveChanges();
                    Console.WriteLine("Create operation completed.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        static void ReadOperation()
        {
            using (var context = new CRUD_DBEntities())
            {
                // Retrieve all students
                var allStudents = context.Students.ToList();
                Console.WriteLine("All Students:");
                foreach (var student in allStudents)
                {
                    Console.WriteLine($"{student.StudentID}: {student.FirstName} {student.LastName}");
                }

                // Retrieve all teachers
                var allTeachers = context.Teachers.ToList();
                Console.WriteLine("\nAll Teachers:");
                foreach (var teacher in allTeachers)
                {
                    Console.WriteLine($"{teacher.TeacherID}: {teacher.FirstName} {teacher.LastName}");
                }

                // Retrieve all courses
                var allCourses = context.Courses.ToList();
                Console.WriteLine("\nAll Courses:");
                foreach (var course in allCourses)
                {
                    Console.WriteLine($"{course.CourseID}: {course.CourseName}");
                }

                // Retrieve all enrollments
                var allEnrollments = context.Enrollments.ToList();
                Console.WriteLine("\nAll Enrollments:");
                foreach (var enrollment in allEnrollments)
                {
                    Console.WriteLine($"{enrollment.EnrollmentID}: StudentID: {enrollment.StudentID}, CourseID: {enrollment.CourseID}");
                }

                Console.WriteLine("Read operation completed.");
            }
        }

        static void UpdateOperation()
        {
            using (var context = new CRUD_DBEntities())
            {
                Console.WriteLine("Choose entity to update:");
                Console.WriteLine("1. Student");
                Console.WriteLine("2. Teacher");
                Console.WriteLine("3. Course");

                if (int.TryParse(Console.ReadLine(), out int entityChoice))
                {
                    switch (entityChoice)
                    {
                        case 1:
                            Console.Write("Enter student ID to update: ");
                            if (int.TryParse(Console.ReadLine(), out int studentId))
                            {
                                var studentToUpdate = context.Students.Find(studentId);

                                if (studentToUpdate != null)
                                {
                                    Console.Write("Enter updated first name: ");
                                    studentToUpdate.FirstName = Console.ReadLine();

                                    Console.Write("Enter updated last name: ");
                                    studentToUpdate.LastName = Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine($"Student with ID {studentId} not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for student ID.");
                            }
                            break;

                        case 2:
                            Console.Write("Enter teacher ID to update: ");
                            if (int.TryParse(Console.ReadLine(), out int teacherId))
                            {
                                var teacherToUpdate = context.Teachers.Find(teacherId);

                                if (teacherToUpdate != null)
                                {
                                    Console.Write("Enter updated first name: ");
                                    teacherToUpdate.FirstName = Console.ReadLine();

                                    Console.Write("Enter updated last name: ");
                                    teacherToUpdate.LastName = Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine($"Teacher with ID {teacherId} not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for teacher ID.");
                            }
                            break;

                        case 3:
                            Console.Write("Enter course ID to update: ");
                            if (int.TryParse(Console.ReadLine(), out int courseId))
                            {
                                var courseToUpdate = context.Courses.Find(courseId);

                                if (courseToUpdate != null)
                                {
                                    Console.Write("Enter updated course name: ");
                                    courseToUpdate.CourseName = Console.ReadLine();

                                    Console.Write("Enter updated credits: ");
                                    if (int.TryParse(Console.ReadLine(), out int updatedCredits))
                                    {
                                        courseToUpdate.Credits = updatedCredits;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input for updated credits.");
                                    }
                                    Console.Write("Enter updated TeacherId: ");
                                    if (int.TryParse(Console.ReadLine(), out int updatedTeacherId))
                                    {
                                        courseToUpdate.TeacherID = updatedTeacherId;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input for updated TeacherId.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Course with ID {courseId} not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for course ID.");
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                            break;
                    }

                    // Save changes to the database
                    context.SaveChanges();
                    Console.WriteLine("Update operation completed.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        static void DeleteOperation()
        {
            using (var context = new CRUD_DBEntities())
            {
                Console.WriteLine("Choose entity to delete:");
                Console.WriteLine("1. Student");
                Console.WriteLine("2. Teacher");
                Console.WriteLine("3. Course");

                if (int.TryParse(Console.ReadLine(), out int entityChoice))
                {
                    switch (entityChoice)
                    {
                        case 1:
                            Console.Write("Enter student ID to delete: ");
                            if (int.TryParse(Console.ReadLine(), out int studentId))
                            {
                                var studentToDelete = context.Students.Find(studentId);

                                if (studentToDelete != null)
                                {
                                    context.Students.Remove(studentToDelete);
                                }
                                else
                                {
                                    Console.WriteLine($"Student with ID {studentId} not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for student ID.");
                            }
                            break;

                        case 2:
                            Console.Write("Enter teacher ID to delete: ");
                            if (int.TryParse(Console.ReadLine(), out int teacherId))
                            {
                                var teacherToDelete = context.Teachers.Find(teacherId);

                                if (teacherToDelete != null)
                                {
                                    context.Teachers.Remove(teacherToDelete);
                                }
                                else
                                {
                                    Console.WriteLine($"Teacher with ID {teacherId} not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for teacher ID.");
                            }
                            break;

                        case 3:
                            Console.Write("Enter course ID to delete: ");
                            if (int.TryParse(Console.ReadLine(), out int courseId))
                            {
                                var courseToDelete = context.Courses.Find(courseId);

                                if (courseToDelete != null)
                                {
                                    context.Courses.Remove(courseToDelete);
                                }
                                else
                                {
                                    Console.WriteLine($"Course with ID {courseId} not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for course ID.");
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                            break;
                    }

                    // Save changes to the database
                    context.SaveChanges();
                    Console.WriteLine("Delete operation completed.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }
}

