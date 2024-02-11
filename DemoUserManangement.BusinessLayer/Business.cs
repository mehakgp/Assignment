using DemoUserManagement.DataAccessLayer;
using DemoUserManagement.UtilityLayer;
using System;
using System.Collections.Generic;
using static DemoUserManagement.ModelView.Model;

namespace DemoUserManangement.BusinessLayer
{
    public class Business
    {
        DataAccess dataAccess = new DataAccess();
        public bool SaveUserDetails(UserDetailsModel userDetails, AddressDetailsModel currentAddress, AddressDetailsModel permanentAddress)
        {
            try
            {
               
                bool success = dataAccess.SaveUserDetails(userDetails, currentAddress, permanentAddress);
                return success;
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
                return false;
            }
        }
        public List<GridViewUserDetailsModel> GetUsers()
        {
            return dataAccess.GetUsers();
        }

        public bool DeleteUser(int userId)
        {
            return dataAccess.DeleteUser(userId);
        }
    }
}
