using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DemoProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "MyFile.txt";
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Write to file");
                Console.WriteLine("2. Read from file");
                Console.WriteLine("3. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        WriteToFile(fileName);
                        break;
                    case "2":
                        ReadFromFile(fileName);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }

            } while (true);
        }

        static void WriteToFile(string fileName)
        {
            Console.WriteLine("Enter text to write to the file (type 'no' to stop):");

            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                string input;
                do
                {
                    input = Console.ReadLine();
                    if (input.ToLower() != "no")
                    {
                        writer.WriteLine(input);
                    }

                } while (input.ToLower() != "no");
            }

            Console.WriteLine("Data written to the file successfully.");
        }

        static void ReadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                Console.WriteLine("File content:");

                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine($"File '{fileName}' does not exist. No content to read.");
            }
        }
    }
    
}
