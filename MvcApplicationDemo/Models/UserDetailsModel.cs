using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationDemo.Models
{
    public class UserDetailsModel
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AadharNo { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
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

        public string OriginalFileName { get; set; }

        public string UniqueFileName { get; set; }
    }
}