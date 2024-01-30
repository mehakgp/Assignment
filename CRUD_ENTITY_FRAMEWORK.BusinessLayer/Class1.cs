using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CRUD_ENTITY_FRAMEWORK.UtilityLayer.Class1;
using static CRUD_ENTITY_FRAMEWORK.DataAccessLayer.Class1;
using System.IO;
using CRUD_ENTITY_FRAMEWORK.DataAccessLayer;

namespace CRUD_ENTITY_FRAMEWORK.BusinessLayer
{
    public class Class1
    {
  
        public static void DisplayCrudOptions()
        {
            DataAccessLayer.Class1.DisplayCrudOptions();

        }
       public static void LogException(Exception ex)
        {
           DataAccessLayer.Class1.LogException(ex);
        }

        public static void CreateOperation()
        {
            DataAccessLayer.Class1.CreateOperation();
        }
       public static void ReadOperation()
        {
           DataAccessLayer.Class1.ReadOperation();
        }
        public static void UpdateOperation()
        {
            DataAccessLayer.Class1.UpdateOperation();
        }
        public static void DeleteOperation()
        {
           DataAccessLayer.Class1.DeleteOperation();
        }
        public enum CrudOperation
        {
            Create = 1,
            Read,
            Update,
            Delete,
            Exit
        }

    }
}
