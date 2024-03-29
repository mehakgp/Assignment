﻿using System;
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
            public DateTime DateOfBirth { get; set; }
            public string AadharNo { get; set; }
            public string Email { get; set; }

            public string Password {  get; set; }
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

        public class AddressDetailsModel
        {
            public int AddressID { get; set; }
            public int UserID { get; set; }
            public int AddressType { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string Pincode { get; set; }
            public int CountryID { get; set; }
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


    }
}
