using DemoUserManagement.DataAccessLayer;
using static DemoUserManagement.UtilityLayer.Utility;
using System;
using System.Collections.Generic;
using System.Data;
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
                LogException(ex);
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
                LogException(ex);   
                return false;
            }
        }
      
        public int GetTotalCountUsers()
        {
            return dataAccess.GetTotalCountUsers();
        }
       public DataTable GetUsers(int startIndex, int endIndex, string sortExpression,string sortDirection)
        {
            return dataAccess.GetUsers(startIndex, endIndex, sortExpression, sortDirection);
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

        public bool NoteExists(int objectID, int objectType)
        {
            return dataAccess.NoteExists(objectID, objectType);
        }
        public void InsertNote(int objectID, int objectType, String note)
        {
            dataAccess.InsertNote(objectID, objectType, note);  
        }

        public int GetTotalCount(int objectID, int objectType)
        {
             return dataAccess.GetTotalCount(objectID, objectType);
        }

        public DataTable GetNotes(int objectID, int objectType, int startIndex, int endIndex, String sortExpression, String sortDirection)
        {
            return  dataAccess.GetNotes(objectID,objectType,startIndex,endIndex, sortExpression, sortDirection);
        }
    }


}
