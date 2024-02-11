using DemoUserManagement.DataAccessLayer;
using DemoUserManagement.UtilityLayer;
using System;
using static DemoUserManagement.ModelView.Model;

namespace DemoUserManangement.BusinessLayer
{
    public class Business
    {
        public bool SaveUserDetails(UserDetailsModel userDetails, AddressDetailsModel currentAddress, AddressDetailsModel permanentAddress)
        {
            try
            {
                DataAccess dataAccess = new DataAccess();
                bool success = dataAccess.SaveUserDetails(userDetails, currentAddress, permanentAddress);
                return success;
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
                return false;
            }
        }
    }
}
