using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CRUD_ENTITY_FRAMEWORK.UtilityLayer.Class1;

namespace CRUD_ENTITY_FRAMEWORK.DataAccessLayer
{
    public class Class1
    {
        public static void DisplayCrudOptions()
        {
            Console.WriteLine($"{(int)CrudOperation.Create}. Create");
            Console.WriteLine($"{(int)CrudOperation.Read}. Read");
            Console.WriteLine($"{(int)CrudOperation.Update}. Update");
            Console.WriteLine($"{(int)CrudOperation.Delete}. Delete");
            Console.WriteLine($"{(int)CrudOperation.Exit}. Exit");
        }

        public static void DisplayEntityOptions()
        {
            Console.WriteLine($"{(int)EntityChoice.Student}. Student");
            Console.WriteLine($"{(int)EntityChoice.Teacher}. Teacher");
            Console.WriteLine($"{(int)EntityChoice.Course}. Course");
        }
        
        public static void LogException(Exception ex)
        {
            try
            {
                Console.WriteLine("Exception occured. Check logfile ");
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now} - Exception: {ex.Message}");
                    writer.WriteLine($"StackTrace: {ex.StackTrace}");
                    writer.WriteLine("--------------------------------------------------");
                }
            }
            catch (Exception logEx)
            {
                Console.WriteLine($"Error writing to log file: {logEx.Message}");
            }
        }
        
        public static void CreateOperation()
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    Console.WriteLine("Choose entity to create:");
                    DisplayEntityOptions();

                    if (Enum.TryParse(Console.ReadLine(), out EntityChoice entityChoice))
                    {
                        switch (entityChoice)
                        {
                            case EntityChoice.Student:
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
                            case EntityChoice.Teacher:
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
                            case EntityChoice.Course:
                                Console.Write("Enter course name: ");
                                string courseName = Console.ReadLine();

                                Console.Write("Enter credits: ");
                                if (int.TryParse(Console.ReadLine(), out int credits))
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
                                Console.WriteLine("Invalid choice. Please enter a valid option.");
                                break;
                        }
                        context.SaveChanges();
                        Console.WriteLine("Create operation completed.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid option.");
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }
        
        public static void ReadOperation()
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    var allStudents = context.Students.ToList();
                    Console.WriteLine("All Students:");
                    foreach (var student in allStudents)
                    {
                        Console.WriteLine($"{student.StudentID}: {student.FirstName} {student.LastName}");
                    }

                    var allTeachers = context.Teachers.ToList();
                    Console.WriteLine("\nAll Teachers:");
                    foreach (var teacher in allTeachers)
                    {
                        Console.WriteLine($"{teacher.TeacherID}: {teacher.FirstName} {teacher.LastName}");
                    }

                    var allCourses = context.Courses.ToList();
                    Console.WriteLine("\nAll Courses:");
                    foreach (var course in allCourses)
                    {
                        Console.WriteLine($"{course.CourseID}: {course.CourseName}");
                    }

                    var allEnrollments = context.Enrollments.ToList();
                    Console.WriteLine("\nAll Enrollments:");
                    foreach (var enrollment in allEnrollments)
                    {
                        Console.WriteLine($"{enrollment.EnrollmentID}: StudentID: {enrollment.StudentID}, CourseID: {enrollment.CourseID}");
                    }

                    Console.WriteLine("Read operation completed.");
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        public static void UpdateOperation()
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    Console.WriteLine("Choose entity to update:");
                    DisplayEntityOptions();

                    if (Enum.TryParse(Console.ReadLine(), out EntityChoice entityChoice))
                    {
                        switch (entityChoice)
                        {
                            case EntityChoice.Student:
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

                            case EntityChoice.Teacher:
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

                            case EntityChoice.Course:
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


                        context.SaveChanges();
                        Console.WriteLine("Update operation completed.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        public static void DeleteOperation()
        {
            try
            {
                using (var context = new CRUD_DBEntities())
                {
                    Console.WriteLine("Choose entity to delete:");
                    DisplayEntityOptions();

                    if (Enum.TryParse(Console.ReadLine(), out EntityChoice entityChoice))
                    {
                        switch (entityChoice)
                        {
                            case EntityChoice.Student:
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

                            case EntityChoice.Teacher:
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

                            case EntityChoice.Course:
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

                        context.SaveChanges();
                        Console.WriteLine("Delete operation completed.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }


    }
}
