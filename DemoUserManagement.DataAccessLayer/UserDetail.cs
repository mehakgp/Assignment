//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoUserManagement.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserDetail()
        {
            this.AddressDetails = new HashSet<AddressDetail>();
            this.UserRoles = new HashSet<UserRole>();
        }
    
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string AadharNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<decimal> Marks10th { get; set; }
        public string Board10th { get; set; }
        public string School10th { get; set; }
        public Nullable<System.DateTime> YearOfCompletion10th { get; set; }
        public Nullable<decimal> Marks12th { get; set; }
        public string Board12th { get; set; }
        public string School12th { get; set; }
        public Nullable<System.DateTime> YearOfCompletion12th { get; set; }
        public Nullable<decimal> CGPA { get; set; }
        public string University { get; set; }
        public Nullable<System.DateTime> YearOfCompletionGraduation { get; set; }
        public string Hobbies { get; set; }
        public string Comments { get; set; }
        public string OriginalFileName { get; set; }
        public string UniqueFileName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddressDetail> AddressDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
