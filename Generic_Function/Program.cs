using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Configuration;

namespace Generic_Function
{
    public static class ExtensionMethods
    {
        public static List<T> ToList<T>(this DataTable dataTable) where T : new()
        {
            List<T> result = new List<T>();

            foreach (DataRow row in dataTable.AsEnumerable())
            {
                T obj = new T();

                foreach (DataColumn column in dataTable.Columns)
                {
                    PropertyInfo property = obj.GetType().GetProperty(column.ColumnName);

                    if (property != null && row[column] != DBNull.Value)
                    {
                        property.SetValue(obj, row[column], null);
                    }
                }

                result.Add(obj);
            }

            return result;
        }
        public static DataTable ToDataTable<T>(this List<T> list) where T : class
        {
            DataTable dataTable = new DataTable();

            if (list.Any())
            {
                PropertyInfo[] properties = typeof(T).GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    dataTable.Columns.Add(new DataColumn(property.Name, property.PropertyType));
                }

                foreach (T obj in list)
                {
                    DataRow row = dataTable.NewRow();

                    foreach (var property in properties)
                    {
                        row[property.Name] = property.GetValue(obj) ?? DBNull.Value;
                    }

                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }

   
    }

    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            DataTable employeesDataTable = GetDataTableFromDatabase(connectionString, "SELECT * FROM Employees");
            List<Employee> employeesList = employeesDataTable.ToList<Employee>();

            DataTable departmentsDataTable = GetDataTableFromDatabase(connectionString, "SELECT * FROM Departments");
            List<Department> departmentsList = departmentsDataTable.ToList<Department>();

            Console.WriteLine("Employees Table:");
            PrintTable(employeesList);

            Console.WriteLine("\nDepartments Table:");
            PrintTable(departmentsList);

            DataTable employeesConvertedDataTable = employeesList.ToDataTable();
            Console.WriteLine("\nConverted Employees DataTable:");
            PrintDataTable(employeesConvertedDataTable);

            DataTable departmentsConvertedDataTable = departmentsList.ToDataTable();
            Console.WriteLine("\nConverted Departments DataTable:");
            PrintDataTable(departmentsConvertedDataTable);

            Console.ReadKey();
        }

        private static void PrintTable<T>(IEnumerable<T> list)
        {
            foreach (var item in list)
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                Console.WriteLine($"{{ {string.Join(", ", properties.Select(prop => $"{prop.Name}: {prop.GetValue(item)}"))} }}");
            }
        }

        private static void PrintDataTable(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                var columnValues = dataTable.Columns
                    .Cast<DataColumn>()
                    .Select(col => "{" + col.ColumnName + ": " + row[col] + "}");

                Console.WriteLine( string.Join(", ", columnValues));
            }
        }

        private static DataTable GetDataTableFromDatabase(string connectionString, string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }

    }

    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }

}
