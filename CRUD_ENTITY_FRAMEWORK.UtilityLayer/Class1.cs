using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ENTITY_FRAMEWORK.UtilityLayer
{
    public class Class1
    {
        public static string logFilePath = "C:\\Users\\mehakg\\Desktop\\Projects\\Assignment\\CRUD_ENTITY_FRAMEWORK.UtilityLayer\\LogFile.txt";

        public enum CrudOperation
        {
            Create = 1,
            Read,
            Update,
            Delete,
            Exit
        }

        public enum EntityChoice
        {
            Student = 1,
            Teacher,
            Course
        }

    }
}
