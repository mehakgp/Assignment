using DemoUserManagement.UtilityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static DemoUserManagement.ModelView.Model;

namespace DemoUserManagement.DataAccessLayer
{
    public class DataAccess
    {

       
        public bool SaveUserDetails(UserDetailsModel userDetails, AddressDetailsModel currentAddress, AddressDetailsModel permanentAddress)
        {
            try
            {
                using (var context = new DemoUserManagementEntities())
                {
                    var user = new UserDetail
                    {
                        FirstName = userDetails.FirstName,
                        LastName = userDetails.LastName,
                        // Populate other user properties similarly
                    };
                    context.UserDetails.Add(user);
                    context.SaveChanges();

                    var current = new AddressDetail
                    {
                        UserID = user.UserID,
                        AddressType = currentAddress.AddressType,
                        AddressLine1 = currentAddress.AddressLine1,
                        AddressLine2 = currentAddress.AddressLine2,
                        Pincode = currentAddress.Pincode,
                        Country = currentAddress.Country,
                        State = currentAddress.State
                    };
                    context.AddressDetails.Add(current);
                    context.SaveChanges();


                    var permanent = new AddressDetail
                    {
                        UserID = user.UserID,
                        AddressType = permanentAddress.AddressType,
                        AddressLine1 = permanentAddress.AddressLine1,
                        AddressLine2 = permanentAddress.AddressLine2,
                        Pincode = permanentAddress.Pincode,
                        Country = permanentAddress.Country,
                        State = permanentAddress.State
                    };
                    context.AddressDetails.Add(permanent);
                    context.SaveChanges();
                }
                return true;
            }

            catch (Exception ex)
            {

                Utility.LogException(ex);
                return false;
            }
        }

        public List<GridViewUserDetailsModel> GetUsers()
        {
            List<GridViewUserDetailsModel> users = new List<GridViewUserDetailsModel>();

            using (var context = new DemoUserManagementEntities())
            {
               
                users = context.UserDetails.Select(u => new GridViewUserDetailsModel
                {
                    UserID = u.UserID,
                    FirstName = u.FirstName,
                    Gender = u.Gender,
                    DateOfBirth = u.DateOfBirth,
                    AadharNo = u.AadharNo,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber
                    // Populate other properties as needed
                }).ToList();
            }

            return users;
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                using (var context = new DemoUserManagementEntities())
                {
                    var user = context.UserDetails.FirstOrDefault(u => u.UserID == userId);
                    if (user != null)
                    {
                        context.UserDetails.Remove(user);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
                return false;
            }
        }
    }
}
