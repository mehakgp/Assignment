using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
namespace CRUD_ENTITY_FRAMEWORK
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Choose CRUD operation:");
                    BusinessLayer.Class1.DisplayCrudOptions();

                    if (Enum.TryParse(Console.ReadLine(), out BusinessLayer.Class1.CrudOperation operation))
                    {
                        switch (operation)
                        {
                            case BusinessLayer.Class1.CrudOperation.Create:
                               BusinessLayer.Class1.CreateOperation();
                                break;
                            case BusinessLayer.Class1.CrudOperation.Read:
                                BusinessLayer.Class1.ReadOperation();
                                break;
                            case BusinessLayer.Class1.CrudOperation.Update:
                                BusinessLayer.Class1.UpdateOperation();
                                break;
                            case BusinessLayer.Class1.CrudOperation.Delete:
                                BusinessLayer.Class1.DeleteOperation();
                                break;
                            case BusinessLayer.Class1.CrudOperation.Exit:
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
                   BusinessLayer.Class1. LogException(ex);
                }
            }
        }
   

    }

}

