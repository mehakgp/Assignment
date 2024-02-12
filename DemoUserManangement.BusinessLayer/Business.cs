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

       public List<CountryModel> GetCountries()
        {
            return dataAccess.GetCountries();
        }
        public List<StateModel> GetStates(int countryId)
        {
            return dataAccess.GetStates(countryId);
        }
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

        public bool EditUserDetails(UserDetailsModel userDetails,AddressDetailsModel currentAddress, AddressDetailsModel permanentAddress , int userID)
        {
            try
            {
                bool successs = dataAccess.EditUserDetails(userDetails, currentAddress, permanentAddress,userID);
                return successs;
            }
            catch(Exception ex)
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

        public UserDetailsModel GetUserDetails(int userID)
        {
            return dataAccess.GetUserDetails(userID);
        }

        public AddressDetailsModel GetAddressDetails(int userID, int addressType) 
        {
         return dataAccess.GetAddressDetails(userID, addressType);
        }
    }

}
