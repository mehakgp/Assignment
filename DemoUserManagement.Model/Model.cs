using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUserManagement.ModelView
{
    public class Model
    {


        public class CountryModel
        {
            public int CountryID { get; set; }
            public string CountryName { get; set; }
        }

        public class StateModel
        {
            public int StateID { get; set; }
            public string StateName { get; set; }
            public int CountryID { get; set; }
        }

        public class UserDetailsModel
        {
            public int UserID { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public string AadharNo { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public decimal? Marks10th { get; set; }
            public string Board10th { get; set; }
            public string School10th { get; set; }
            public DateTime? YearOfCompletion10th { get; set; }
            public decimal? Marks12th { get; set; }
            public string Board12th { get; set; }
            public string School12th { get; set; }
            public DateTime? YearOfCompletion12th { get; set; }
            public decimal? CGPA { get; set; }
            public string University { get; set; }
            public DateTime? YearOfCompletionGraduation { get; set; }
            public string Hobbies { get; set; }
            public string Comments { get; set; }
        }

        public class AddressDetailsModel
        {
            public int AddressID { get; set; }
            public int UserID { get; set; }
            public int AddressType { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string Pincode { get; set; }
            public string Country { get; set; }
            public string State { get; set; }
        }

        public class GridViewUserDetailsModel
        {
            public int UserID { get; set; }
            public string FirstName { get; set; }
            public string Gender { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public string AadharNo { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
       
        }
    }
}
