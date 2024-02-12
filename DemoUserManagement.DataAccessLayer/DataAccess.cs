using DemoUserManagement.UtilityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static DemoUserManagement.ModelView.Model;

namespace DemoUserManagement.DataAccessLayer
{
    public class DataAccess
    {
        public List<CountryModel> GetCountries()
        {
            using (var context = new DemoUserManagementEntities())
            {
                return context.Countries
                    .Select(c => new CountryModel
                    {
                        CountryID = c.CountryID,
                        CountryName = c.CountryName
                    })
                    .ToList();
            }
        }

        public List<StateModel> GetStates(int countryId)
        {
            using (var context = new DemoUserManagementEntities())
            {
                return context.States
                    .Where(s => s.CountryID == countryId)
                    .Select(s => new StateModel
                    {
                        StateID = s.StateID,
                        StateName = s.StateName,
                        CountryID = (int)s.CountryID
                    })
                    .ToList();
            }
        }

        public bool SaveUserDetails(UserDetailsModel userDetails, AddressDetailsModel currentAddress, AddressDetailsModel permanentAddress)
        {
            try
            {
                using (var context = new DemoUserManagementEntities())
                {
                    var user = new UserDetail
                    {
                        FirstName = userDetails.FirstName,
                        MiddleName = userDetails.MiddleName,
                        LastName = userDetails.LastName,
                        Gender = userDetails.Gender,
                        DateOfBirth = userDetails.DateOfBirth,
                        AadharNo    = userDetails.AadharNo,
                        Email = userDetails.Email,
                        PhoneNumber = userDetails.PhoneNumber,  
                        Marks10th   = userDetails.Marks10th,    
                        Board10th = userDetails.Board10th,
                        School10th = userDetails.School10th,    
                        YearOfCompletion10th = userDetails.YearOfCompletion10th,
                        Marks12th = userDetails.Marks12th,
                        Board12th   = userDetails.Board12th,
                        School12th  = userDetails.School12th,
                        YearOfCompletion12th    = userDetails.YearOfCompletion12th,
                        CGPA  =userDetails.CGPA,
                        University = userDetails.University,    
                        YearOfCompletionGraduation  = userDetails.YearOfCompletionGraduation,
                        Hobbies = userDetails.Hobbies,
                        Comments    = userDetails.Comments,
                      
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

        public bool EditUserDetails(UserDetailsModel userDetails, AddressDetailsModel currentAddress, AddressDetailsModel permanentAddress, int userID)
        {
            try
            {
                using (var context = new DemoUserManagementEntities())
                {
                   
                    var user = context.UserDetails.FirstOrDefault(u => u.UserID == userID);
                    if (user != null)
                    {
                  
                        user.FirstName = userDetails.FirstName;
                        user.FirstName = userDetails.FirstName;
                        user.MiddleName = userDetails.MiddleName;
                        user.LastName = userDetails.LastName;
                        user.Gender = userDetails.Gender;
                        user.DateOfBirth = userDetails.DateOfBirth;
                        user.AadharNo = userDetails.AadharNo;
                        user.Email = userDetails.Email;
                        user.PhoneNumber = userDetails.PhoneNumber;
                        user.Marks10th = userDetails.Marks10th;
                        user.Board10th = userDetails.Board10th;
                        user.School10th = userDetails.School10th;
                        user.YearOfCompletion10th = userDetails.YearOfCompletion10th;
                        user.Marks12th = userDetails.Marks12th;
                        user.Board12th = userDetails.Board12th;
                        user.School12th = userDetails.School12th;
                        user.YearOfCompletion12th = userDetails.YearOfCompletion12th;
                        user.CGPA = userDetails.CGPA;
                        user.University = userDetails.University;
                        user.YearOfCompletionGraduation = userDetails.YearOfCompletionGraduation;
                        user.Hobbies = userDetails.Hobbies;
                        user.Comments = userDetails.Comments;
                      
                        var current = context.AddressDetails.FirstOrDefault(a => a.UserID == userID && a.AddressType == currentAddress.AddressType);
                        if (current != null)
                        {
                            current.AddressLine1 = currentAddress.AddressLine1;
                            current.AddressLine2 = currentAddress.AddressLine2;
                            current.Pincode = currentAddress.Pincode;
                            current.Country = currentAddress.Country;
                            current.State = currentAddress.State;
                        }

                        var permanent = context.AddressDetails.FirstOrDefault(a => a.UserID == userID && a.AddressType == permanentAddress.AddressType);
                        if (permanent != null)
                        {
                            permanent.AddressLine1 = permanentAddress.AddressLine1;
                            permanent.AddressLine2 = permanentAddress.AddressLine2;
                            permanent.Pincode = permanentAddress.Pincode;
                            permanent.Country = permanentAddress.Country;
                            permanent.State = permanentAddress.State;
                        }

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

        public UserDetailsModel GetUserDetails(int userID)
        {
            using (var context = new DemoUserManagementEntities())
            {
                var user = context.UserDetails.FirstOrDefault(u => u.UserID == userID);
                if (user != null)
                {
                    return new UserDetailsModel
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        MiddleName = user.MiddleName,
                        Gender = user.Gender,
                        DateOfBirth = user.DateOfBirth,
                        AadharNo = user.AadharNo,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Marks10th = user.Marks10th,
                        Board10th = user.Board10th, 
                        School10th = user.School10th,
                        YearOfCompletion10th = user.YearOfCompletion10th,
                        Marks12th = user.Marks12th,
                        Board12th = user.Board12th,
                        School12th = user.School12th,
                        YearOfCompletion12th = user.YearOfCompletion12th,
                        CGPA = user.CGPA,
                        University  = user.University,
                        YearOfCompletionGraduation = user.YearOfCompletionGraduation,
                        Hobbies = user.Hobbies,
                        Comments = user.Comments,
                
                    };
                }
                return null;
            }
        }

        public AddressDetailsModel GetAddressDetails(int userID, int addressType)
        {
           
                using (var context = new DemoUserManagementEntities())
                {
                    var address = context.AddressDetails.FirstOrDefault(a => a.UserID == userID && a.AddressType == addressType);
                    if (address != null)
                    {
                        return new AddressDetailsModel
                        {
                            UserID = (int)address.UserID,
                            AddressType = (int)address.AddressType,
                            AddressLine1 = address.AddressLine1,
                            AddressLine2 = address.AddressLine2,
                            Pincode = address.Pincode,
                            Country = address.Country,
                            State = address.State
                        };
                    }
                    return null;
                }
            
        }
    }

}