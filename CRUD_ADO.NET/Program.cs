using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace CRUD_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Program obj = new Program();
            int choice;
            do
            {
                Console.WriteLine("\nChoose an operation:");
                Console.WriteLine("1. Create Table");
                Console.WriteLine("2. Insert Record");
                Console.WriteLine("3. Display Data");
                Console.WriteLine("4. Update Record");
                Console.WriteLine("5. Delete Record");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice (1-5): ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        obj.CreateTable();
                        break;
                    case 2:
                        obj.InsertRecord();
                        break;
                    case 3:
                        obj.DisplayData();
                        break;
                    case 4:
                        obj.UpdateRecord();
                        break;
                    case 5:
                        obj.DeleteData();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            } while (choice != 6);
            Console.ReadKey();

        }

        private SqlConnection GetSqlConnection()
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return new SqlConnection(ConString);
        }

        public void CreateTable()
        {
            SqlConnection con = null;
            try
            {
                con = GetSqlConnection();
                SqlCommand cm = new SqlCommand("create table student(id int not null, name varchar(100), email varchar(50), join_date date)", con);
                con.Open();
                cm.ExecuteNonQuery();
                Console.WriteLine("Table created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("something went wrong." + e);
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertRecord()
        {
            SqlConnection con = null;
            try
            {
                con = GetSqlConnection();
                Console.Write("Enter ID: ");
                string id = Console.ReadLine();
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Email: ");
                string email = Console.ReadLine();
                Console.Write("Enter Join Date (YYYY-MM-DD): ");
                string joinDate = Console.ReadLine();

                SqlCommand cm = new SqlCommand($"insert into student (id, name, email, join_date) values ('{id}', '{name}', '{email}', '{joinDate}')", con);
                con.Open();
                cm.ExecuteNonQuery();
                Console.WriteLine("Record Inserted Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("something went wrong." + e);
            }
            finally
            {
                con.Close();
            }
        }

        public void DisplayData()
        {
            SqlConnection con = null;
            try
            {
                con = GetSqlConnection();
                SqlCommand cm = new SqlCommand("Select * from student", con);
                con.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["id"] + " " + sdr["name"] + " " + sdr["email"] + " " + sdr["join_date"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("something went wrong." + e);
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateRecord()
        {
            SqlConnection con = null;
            try
            {
                con = GetSqlConnection();
                Console.Write("Enter ID to update: ");
                string idToUpdate = Console.ReadLine();
                Console.Write("Enter New Name: ");
                string newName = Console.ReadLine();

                SqlCommand cm = new SqlCommand($"update student set name = '{newName}' where id = '{idToUpdate}'", con);
                con.Open();
                int rowsAffected = cm.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Record Updated Successfully");
                else
                    Console.WriteLine($"No record found with ID '{idToUpdate}'.");
            }
            catch (Exception e)
            {
                Console.WriteLine("something went wrong." + e);
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteData()
        {
            SqlConnection con = null;
            try
            {
                con = GetSqlConnection();
                Console.Write("Enter ID to delete: ");
                string idToDelete = Console.ReadLine();

                SqlCommand cm = new SqlCommand($"delete from student where id = '{idToDelete}'", con);
                con.Open();
                int rowsAffected = cm.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Record Deleted Successfully");
                else
                    Console.WriteLine($"No record found with ID '{idToDelete}'.");
            }
            catch (Exception e)
            {
                Console.WriteLine("something went wrong." + e);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
