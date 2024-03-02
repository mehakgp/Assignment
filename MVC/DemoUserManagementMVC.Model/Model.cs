using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DemoUserManagementMVC.ModelView
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

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Aadhar No is required")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Aadhar No must be 12 digits")]
        public string AadharNo { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone Number must be 10 digits")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Percentage is required")]
        [Range(1, 100, ErrorMessage = "Percentage must be between 1 and 100")]
        public decimal? Marks10th { get; set; }

        public string Board10th { get; set; }
        public string School10th { get; set; }
        public DateTime YearOfCompletion10th { get; set; }

        [Required(ErrorMessage = "Percentage is required")]
        [Range(1, 100, ErrorMessage = "Percentage must be between 1 and 100")]
        public decimal? Marks12th { get; set; }

        public string Board12th { get; set; }
        public string School12th { get; set; }
        public DateTime YearOfCompletion12th { get; set; }

        [Required(ErrorMessage = "CGPA is required")]
        [Range(1, 10, ErrorMessage = "CGPA must be between 1 and 10")]
        public decimal? CGPA { get; set; }

        public string University { get; set; }
        public DateTime YearOfCompletionGraduation { get; set; }
        public string Hobbies { get; set; }
        public string Comments { get; set; }

        public string OriginalFileName { get; set; }
        public string UniqueFileName { get; set; }
    }

    public class AddressDetailsModel
    {
        public int AddressID { get; set; }
        public int UserID { get; set; }
        public int AddressType { get; set; }

        [Required(ErrorMessage = "Address Line 1 is required")]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Pincode is required")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Pincode must be 6 digits")]
        public string Pincode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public int CountryID { get; set; }

        [Required(ErrorMessage = "State is required")]
        public int StateID { get; set; }
    }
    public class DocumentModel
    {
        public int ID { get; set; }
        public int ObjectID { get; set; }
        public int ObjectType { get; set; }
        public int DocumentType { get; set; }
        public string DocumentOriginalName { get; set; }
        public string DocumentUniqueName { get; set; }
        public DateTime DateTime { get; set; }
    }
    public class DocumentTypeModel
    {
        public int DocumentId { get; set; }
        public string DocumentTypeName { get; set; }
    }

    public class SessionModel
    {
        public int UserID { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class UserModel
    {
        public UserDetailsModel UserDetails { get; set; }

        public AddressDetailsModel CurrentAddress { get; set; }

        public AddressDetailsModel PermanentAddress { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

 

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }
    }

    public class UserListModel
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AadharNo { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }


    public class PagedUserListModel
    {
        public List<UserListModel> Users { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortExpression { get; set; }
        public string SortDirection { get; set; }
    }

    public class NoteModel
    {
        public int ID { get; set; }
        public int ObjectID { get; set; }
        public int ObjectType { get; set; }
        public string Note { get; set; }
        public DateTime DateTime { get; set; }
    }

}

