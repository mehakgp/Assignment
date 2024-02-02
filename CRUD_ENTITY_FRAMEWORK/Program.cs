using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CRUD_ENTITY_FRAMEWORK.BusinessLayer;
using static CRUD_ENTITY_FRAMEWORK.UtilityLayer.Utility;
using static CRUD_ENTITY_FRAMEWORK.ModelView.Model;
using OfficeOpenXml;
using System.Configuration;
using System.Data.Entity.Core.Metadata.Edm;

namespace CRUD_ENTITY_FRAMEWORK
{
    internal class Program
    {
        public static void DisplayCrudOptions()
        {
            Console.WriteLine($"{(int)CrudOperation.Create}.Create");
            Console.WriteLine($"{(int)CrudOperation.Read}.Read");
            Console.WriteLine($"{(int)CrudOperation.Update}.Update");
            Console.WriteLine($"{(int)CrudOperation.Delete}.Delete");
            Console.WriteLine($"{(int)CrudOperation.Export}.Export");
            Console.WriteLine($"{(int)CrudOperation.Exit}.Exit");
        }

        public static void DisplayEntityOptions()
        {

            Console.WriteLine($"{(int)EntityChoice.Student}.Student");
            Console.WriteLine($"{(int)EntityChoice.Teacher}.Teacher");
            Console.WriteLine($"{(int)EntityChoice.Course}.Course");
            Console.WriteLine($"{(int)EntityChoice.Enrollment}.Enrollment");

        }

        public static void DisplayReadOptions()
        {
            Console.WriteLine($"{(int)ChoiceForReadOperation.Student}.Student");
            Console.WriteLine($"{(int)ChoiceForReadOperation.Teacher}.Teacher");
            Console.WriteLine($"{(int)ChoiceForReadOperation.Course}.Course");
            Console.WriteLine($"{(int)ChoiceForReadOperation.Enrollment}.Enrollment");
            Console.WriteLine($"{(int)ChoiceForReadOperation.StudentsInCourse}.Students in a Course");
            Console.WriteLine($"{(int)ChoiceForReadOperation.CoursesByStudent}.Courses taken by a Student");
            Console.WriteLine($"{(int)ChoiceForReadOperation.CoursesAndStudentsByTeacher}.Students and Courses taught by a Teacher");


        }



        private static ChoiceForReadOperation GetReadChoice()
        {
            if (Enum.TryParse(Console.ReadLine(), out ChoiceForReadOperation readChoice))
            {
                return readChoice;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid option.");
                return ChoiceForReadOperation.Exit;
            }
        }

        private static EntityChoice GetEntityChoice()
        {
            if (Enum.TryParse(Console.ReadLine(), out EntityChoice entityChoice))
            {
                return entityChoice;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid option.");
                return EntityChoice.Exit;
            }
        }



        private static StudentModel GetStudentData()
        {
            Console.Write("Enter student's first name: ");
            string firstNameStudent = Console.ReadLine();

            Console.Write("Enter student's last name: ");
            string lastNameStudent = Console.ReadLine();

            return new StudentModel
            {
                FirstName = firstNameStudent,
                LastName = lastNameStudent
            };
        }

        private static TeacherModel GetTeacherData()
        {
            Console.Write("Enter teacher's first name: ");
            string firstNameTeacher = Console.ReadLine();

            Console.Write("Enter teacher's last name: ");
            string lastNameTeacher = Console.ReadLine();

            return new TeacherModel
            {
                FirstName = firstNameTeacher,
                LastName = lastNameTeacher
            };
        }

        private static CourseModel GetCourseData()
        {
            Console.Write("Enter course name: ");
            string courseName = Console.ReadLine();

            Console.Write("Enter credits: ");
            if (int.TryParse(Console.ReadLine(), out int credits))
            {
                Console.Write("Enter teacher ID: ");
                if (int.TryParse(Console.ReadLine(), out int teacherID))
                {
                    return new CourseModel
                    {
                        CourseName = courseName,
                        Credits = credits,
                        TeacherID = teacherID
                    };
                }
                else
                {
                    Console.WriteLine("Invalid input for teacher ID.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for credits.");
            }

            return null;
        }

        private static EnrollmentModel GetErollmentData()
        {

            Console.Write("Enter Student ID: ");
            if (int.TryParse(Console.ReadLine(), out int studentID))
            {
                Console.Write("Enter Course ID: ");
                if (int.TryParse(Console.ReadLine(), out int courseID))
                {
                    return new EnrollmentModel
                    {
                        StudentID = studentID,
                        CourseID = courseID

                    };
                }
                else
                {
                    Console.WriteLine("Invalid input for course ID.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for student ID.");
            }

            return null;
        }



        public static void CreateOperation()
        {
            Console.WriteLine("Choose entity to create:");
            DisplayEntityOptions();
            var entityChoice = GetEntityChoice();

            bool success = false;

            switch (entityChoice)
            {
                case EntityChoice.Student:
                    success = Business.CreateStudent(GetStudentData());
                    break;
                case EntityChoice.Teacher:
                    success = Business.CreateTeacher(GetTeacherData());
                    break;
                case EntityChoice.Course:
                    success = Business.CreateCourse(GetCourseData());
                    break;
                case EntityChoice.Enrollment:
                    success = Business.CreateEnrollment(GetErollmentData());
                    break;
                default:
                    Console.WriteLine("Invalid entity choice.");
                    break;
            }

            if (success)
            {
                Console.WriteLine("Create operation completed successfully.");
            }
            else
            {
                Console.WriteLine("Create operation failed.");
            }
        }

        public static void ReadOperation()
        {
            Console.WriteLine("Choose entity to read:");
            DisplayReadOptions();
            var readChoice = GetReadChoice();

            object entityData = null;
         

            switch (readChoice)
            {
                case ChoiceForReadOperation.Student:
                    entityData = Business.GetAllStudents();
                    Console.WriteLine("\nAll Students:");
                    break;
                case ChoiceForReadOperation.Teacher:
                    entityData = Business.GetAllTeachers();
                    Console.WriteLine("\nAll Teachers:");
                    break;
                case ChoiceForReadOperation.Course:
                    entityData = Business.GetAllCourses();
                    Console.WriteLine("\nAll Courses:");
                    break;
                case ChoiceForReadOperation.Enrollment:
                    entityData = Business.GetAllEnrollments();
                    Console.WriteLine("\nAll Enrollments:");
                    break;
                case ChoiceForReadOperation.StudentsInCourse:
                    Console.Write("Enter Course ID: ");
                    if (int.TryParse(Console.ReadLine(), out int courseID))
                    {
                        entityData = Business.GetStudentsByCourse(courseID);
                        Console.WriteLine($"\nAll Students in Course {courseID}:");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for course ID.");
                    }
                    break;
                case ChoiceForReadOperation.CoursesByStudent:
                    Console.Write("Enter Student ID: ");
                    if (int.TryParse(Console.ReadLine(), out int studentID))
                    {
                        entityData = Business.GetCoursesByStudent(studentID);
                        Console.WriteLine($"\nAll Courses studied by Student {studentID}:");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for student ID.");
                    }
                    break;
                case ChoiceForReadOperation.CoursesAndStudentsByTeacher:
                    Console.Write("Enter Teacher ID: ");
                    if (int.TryParse(Console.ReadLine(), out int teacherID))
                    {
                        entityData = Business.GetCoursesAndStudentsByTeacher(teacherID);
                        Console.WriteLine($"\nAll Courses and Students taught by Teacher {teacherID}:");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for teacher ID.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid entity choice.");
                    return;
            }

            PrintEntity(entityData);
        }

        public static void UpdateOperation()
        {
            Console.WriteLine("Choose entity to update:");
            DisplayEntityOptions();
            var entityChoice = GetEntityChoice();
            bool success = false;
                      
                switch (entityChoice)
                {
                    case EntityChoice.Student:
                        Console.Write("Enter ID of the student to update: ");
                        if (int.TryParse(Console.ReadLine(), out int studentID))
                            success = Business.UpdateStudent(GetStudentData(), studentID);
                        else
                        Console.WriteLine("Invalid input for Student ID.");
                    break;

                    case EntityChoice.Teacher:
                    Console.Write("Enter ID of the teacher to update: ");
                    if (int.TryParse(Console.ReadLine(), out int teacherID))
                        success = Business.UpdateTeacher(GetTeacherData(), teacherID);
                    else
                        Console.WriteLine("Invalid input for Teacher ID.");
                    break;

                    case EntityChoice.Course:
                    Console.Write("Enter ID of the course to update: ");
                    if (int.TryParse(Console.ReadLine(), out int courseID))
                        success = Business.UpdateCourse(GetCourseData(), courseID);
                    else
                        Console.WriteLine("Invalid input for Course ID.");
                    break;

                    case EntityChoice.Enrollment:
                    Console.Write("Enter ID of the enrollment to update: ");
                    if (int.TryParse(Console.ReadLine(), out int enrollmentID))
                        success = Business.UpdateEnrollment(GetErollmentData(), enrollmentID);
                    else
                        Console.WriteLine("Invalid input for Enrollment ID.");
                    break;
                    default:
                        Console.WriteLine("Invalid entity choice.");
                        break;
                }

                if (success)
                {
                    Console.WriteLine("Update operation completed successfully.");
                }
                else
                {
                    Console.WriteLine("Update operation failed.");
                }
            
           
        }

        public static void DeleteOperation()
        {
            Console.WriteLine("Choose entity to delete:");
            DisplayEntityOptions();
            var entityChoice = GetEntityChoice();
            bool success = false;


            switch (entityChoice)
            {
                case EntityChoice.Student:
                    Console.Write("Enter ID of the student to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int studentID))
                        success = Business.DeleteStudent(studentID);
                    else
                        Console.WriteLine("Invalid input for Student ID.");
                    break;

                case EntityChoice.Teacher:
                    Console.Write("Enter ID of the teacher to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int teacherID))
                        success = Business.DeleteTeacher(teacherID);
                    else
                        Console.WriteLine("Invalid input for Teacher ID.");
                    break;

                case EntityChoice.Course:
                    Console.Write("Enter ID of the course to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int courseID))
                        success = Business.DeleteCourse(courseID);
                    else
                        Console.WriteLine("Invalid input for Course ID.");
                    break;

                case EntityChoice.Enrollment:
                    Console.Write("Enter ID of the enrollment to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int enrollmentID))
                        success = Business.DeleteEnrollment(enrollmentID);
                    else
                        Console.WriteLine("Invalid input for Enrollment ID.");
                    break;

                default:
                    Console.WriteLine("Invalid entity choice.");
                    break;
            }

            if (success)
            {
                Console.WriteLine("Delete operation completed successfully.");
            }
            else
            {
                Console.WriteLine("Delete operation failed.");
            }
        }

    

    private static void PrintEntity(object entityData)
    {

        if (entityData is IEnumerable<object> entities)
        {
            foreach (var entity in entities)
            {
                PrintProperties(entity);
            }
            Console.WriteLine("Read operation completed.");
        }
        else
        {
            Console.WriteLine($"No Data found.");
        }
    }

        private static void PrintProperties(object obj)
        {
            var properties = obj.GetType().GetProperties();
           
            foreach (var property in properties)
            {
                Console.Write($"{property.Name}: ");

                if (property.PropertyType.IsGenericType &&
                    property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    
                    var list = (IEnumerable<object>)property.GetValue(obj);
                    foreach (var item in list)
                    {
                        Console.WriteLine("\n");
                        PrintProperties(item);

                    }
                }
                else
                {
                    Console.WriteLine($"{property.GetValue(obj)}");
                }
            }

            Console.WriteLine();
        }



        static void Main(string[] args)
    {

        while (true)
        {
            try
            {
                Console.WriteLine("Choose CRUD operation:");
                DisplayCrudOptions();

                if (Enum.TryParse(Console.ReadLine(), out CrudOperation operation))
                {
                    switch (operation)
                    {
                        case CrudOperation.Create:
                            CreateOperation();
                            break;
                        case CrudOperation.Read:
                            ReadOperation();
                            break;
                        case CrudOperation.Update:
                            UpdateOperation();
                            break;
                        case CrudOperation.Delete:
                            DeleteOperation();
                            break;
                        case CrudOperation.Export:
                            ExportOperation();
                            break;
                        case CrudOperation.Exit:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a number only.");
                }
            }

            catch (Exception ex)
            {
                LogException(ex);
            }
        }

    }

    public static void ExportOperation()
    {
        Console.WriteLine("Choose entity to export:");
        DisplayEntityOptions();
        var entityChoice = GetEntityChoice();

        List<object> entityData = Business.GetAllDataForEntity(entityChoice);

        if (entityData.Any())
        {
            Console.WriteLine("Choose export format:");
            Console.WriteLine($"{(int)ExportFormat.Excel}. Excel");
            Console.WriteLine($"{(int)ExportFormat.CSV}. CSV");

            if (Enum.TryParse(Console.ReadLine(), out ExportFormat exportFormat))
            {
                switch (exportFormat)
                {
                    case ExportFormat.Excel:
                        ExportToExcel(entityChoice.ToString(), entityData);
                        break;
                    case ExportFormat.CSV:
                        ExportToCSV(entityChoice.ToString(), entityData);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input for export format. Please enter a number only.");
            }
        }
        else
        {
            Console.WriteLine($"No data found for {entityChoice.ToString()}.");
        }
    }

    private static void ExportToCSV(string entityName, List<object> data)
    {
        string fileName = $"{entityName}_{DateTime.Now.ToString("yyyy-MM-dd")}.csv";
            string folderPath = ConfigurationManager.AppSettings["ExportFolderPath"];
            string filePath = Path.Combine(folderPath, fileName);

        var properties = data.First().GetType().GetProperties();
        string header = string.Join(",", properties.Select(p => p.Name));
        File.WriteAllText(filePath, header + Environment.NewLine);


        foreach (var item in data)
        {
            string line = string.Join(",", properties.Select(p => Convert.ToString(p.GetValue(item))));
            File.AppendAllText(filePath, line + Environment.NewLine);
        }

        Console.WriteLine("Export successful");
    }
    private static void ExportToExcel(string entityName, List<object> data)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Sheet1");

            var properties = data.First().GetType().GetProperties();
            for (int i = 1; i <= properties.Length; i++)
            {
                worksheet.Cells[1, i].Value = properties[i - 1].Name;
            }

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 1; j <= properties.Length; j++)
                {
                    worksheet.Cells[i + 2, j].Value = properties[j - 1].GetValue(data[i]);
                }
            }

            string fileName = $"{entityName}_{DateTime.Now.ToString("yyyy-MM-dd")}.xlsx";

                string folderPath = ConfigurationManager.AppSettings["ExportFolderPath"];
                string filePath = Path.Combine(folderPath, fileName);

                FileInfo excelFile = new FileInfo(filePath);
            package.SaveAs(excelFile);

            Console.WriteLine("Export successful.");
        }
    }




}

}

