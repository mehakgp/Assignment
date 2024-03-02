using DemoUserManagementMVC.DataAccessLayer;
using static DemoUserManagementMVC.UtilityLayer.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using DemoUserManagementMVC.ModelView;

namespace DemoUserManangementMVC.BusinessLayer
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
        public bool SaveUserDetails(UserModel user)
        {
            try
            {
                UserDetailsModel userDetails = new UserDetailsModel()
                {
                    FirstName = user.UserDetails.FirstName,
                    MiddleName = user.UserDetails.MiddleName,
                    LastName = user.UserDetails.LastName,
                    Gender = user.UserDetails.Gender,
                    DateOfBirth = user.UserDetails.DateOfBirth,
                    AadharNo = user.UserDetails.AadharNo,
                    Email = user.UserDetails.Email,
                    Password = user.UserDetails.Password,
                    PhoneNumber = user.UserDetails.PhoneNumber,
                    Marks10th = user.UserDetails.Marks10th,
                    Board10th = user.UserDetails.Board10th,
                    School10th = user.UserDetails.School10th,
                    YearOfCompletion10th = user.UserDetails.YearOfCompletion10th,
                    Marks12th = user.UserDetails.Marks12th,
                    Board12th = user.UserDetails.Board12th,
                    School12th = user.UserDetails.School12th,
                    YearOfCompletion12th = user.UserDetails.YearOfCompletion12th,
                    CGPA = user.UserDetails.CGPA,
                    University = user.UserDetails.University,
                    YearOfCompletionGraduation = user.UserDetails.YearOfCompletionGraduation,
                    Hobbies = user.UserDetails.Hobbies,
                    Comments = user.UserDetails.Comments,
                    OriginalFileName = user.UserDetails.OriginalFileName,
                    UniqueFileName = user.UserDetails.UniqueFileName,

                };
                AddressDetailsModel currentAddress = new AddressDetailsModel()
                {
                    AddressType = (int)AddressTypeEnum.Current,
                    AddressLine1 = user.CurrentAddress.AddressLine1,
                    AddressLine2 = user.CurrentAddress.AddressLine2,
                    Pincode = user.CurrentAddress.Pincode,
                    CountryID = user.CurrentAddress.CountryID,
                    StateID = user.CurrentAddress.StateID,
                };
                AddressDetailsModel permanentAddress = new AddressDetailsModel()
                {
                    AddressType = (int)AddressTypeEnum.Permanent,
                    AddressLine1 = user.PermanentAddress.AddressLine1,
                    AddressLine2 = user.PermanentAddress.AddressLine2,
                    Pincode = user.PermanentAddress.Pincode,
                    CountryID = user.PermanentAddress.CountryID,
                    StateID = user.PermanentAddress.StateID,
                };

                bool success = dataAccess.SaveUserDetails(userDetails, currentAddress, permanentAddress);
                return success;
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }

        public bool EditUserDetails(UserModel user, int userID)
        {
            try
            {
                UserDetailsModel userDetails = new UserDetailsModel()
                {
                    FirstName = user.UserDetails.FirstName,
                    MiddleName = user.UserDetails.MiddleName,
                    LastName = user.UserDetails.LastName,
                    Gender = user.UserDetails.Gender,
                    DateOfBirth = user.UserDetails.DateOfBirth,
                    AadharNo = user.UserDetails.AadharNo,
                    Email = user.UserDetails.Email,
                    Password = user.UserDetails.Password,
                    PhoneNumber = user.UserDetails.PhoneNumber,
                    Marks10th = user.UserDetails.Marks10th,
                    Board10th = user.UserDetails.Board10th,
                    School10th = user.UserDetails.School10th,
                    YearOfCompletion10th = user.UserDetails.YearOfCompletion10th,
                    Marks12th = user.UserDetails.Marks12th,
                    Board12th = user.UserDetails.Board12th,
                    School12th = user.UserDetails.School12th,
                    YearOfCompletion12th = user.UserDetails.YearOfCompletion12th,
                    CGPA = user.UserDetails.CGPA,
                    University = user.UserDetails.University,
                    YearOfCompletionGraduation = user.UserDetails.YearOfCompletionGraduation,
                    Hobbies = user.UserDetails.Hobbies,
                    Comments = user.UserDetails.Comments,
                    OriginalFileName = user.UserDetails.OriginalFileName,
                    UniqueFileName = user.UserDetails.UniqueFileName,
                };
                AddressDetailsModel currentAddress = new AddressDetailsModel()
                {
                    AddressType = (int)AddressTypeEnum.Current,
                    AddressLine1 = user.CurrentAddress.AddressLine1,
                    AddressLine2 = user.CurrentAddress.AddressLine2,
                    Pincode = user.CurrentAddress.Pincode,
                    CountryID = user.CurrentAddress.CountryID,
                    StateID = user.CurrentAddress.StateID,
                };
                AddressDetailsModel permanentAddress = new AddressDetailsModel()
                {
                    AddressType = (int)AddressTypeEnum.Permanent,
                    AddressLine1 = user.PermanentAddress.AddressLine1,
                    AddressLine2 = user.PermanentAddress.AddressLine2,
                    Pincode = user.PermanentAddress.Pincode,
                    CountryID = user.PermanentAddress.CountryID,
                    StateID = user.PermanentAddress.StateID,
                };
                bool successs = dataAccess.EditUserDetails(userDetails, currentAddress, permanentAddress, userID);
                return successs;
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }

        public PagedUserListModel GetUsers(int page, int pageSize, string sortExpression, string sortDirection)
        {
            int startIndex = (page - 1) * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;

            int totalCount = dataAccess.GetTotalCountUsers();
            List<UserListModel> users = dataAccess.GetUsers(startIndex, endIndex, sortExpression, sortDirection);

            var model = new PagedUserListModel
            {
                Users = users,
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = pageSize,
                SortExpression = sortExpression,
                SortDirection = sortDirection
            };
            return model;
        }
        public bool DeleteUser(int userId)
        {
            return dataAccess.DeleteUser(userId);
        }

        public UserModel GetFormDetails(int userID)
        {
            UserModel user = new UserModel();

            UserDetailsModel userDetails = dataAccess.GetUserDetails(userID);
            if (userDetails != null)
            {
                user.UserDetails = userDetails;

                AddressDetailsModel currentAddress = dataAccess.GetAddressDetails(userID, (int)AddressTypeEnum.Current);
                if (currentAddress != null)
                {
                    user.CurrentAddress = currentAddress;
                }

                AddressDetailsModel permanentAddress = dataAccess.GetAddressDetails(userID, (int)AddressTypeEnum.Permanent);
                if (permanentAddress != null)
                {
                    user.PermanentAddress = permanentAddress;
                }
            }
            return user;
        }

        public bool LogIn(LoginViewModel model)
        {
            int userID = dataAccess.GetUserByEmailAndPassword(model.Email, model.Password);
            if (userID != -1)
            {
                bool isAdmin = dataAccess.CheckIfUserIsAdmin(userID);
                SessionModel userSessionInfo = new SessionModel
                {
                    UserID = userID,
                    IsAdmin = isAdmin
                };

                SetUserSessionInfo(userSessionInfo);
                return true;
            }
            return false;
        }

        public bool InsertNote(int objectID, int objectType, String note)
        {
            return dataAccess.InsertNote(objectID, objectType, note);
        }

        public int GetTotalPagesOfNote(int objectID, int objectType, int pageSize)
        {
            int totalCount = dataAccess.GetTotalCountNote(objectID, objectType);
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            return totalPages;
        }
        public int GetTotalPagesOfDocument(int objectID, int objectType, int pageSize)
        {
            int totalCount = dataAccess.GetTotalCountDocument(objectID, objectType);
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            return totalPages;
        }


        public List<NoteModel> GetNotes(int objectID, int objectType, int page, int pageSize, String sortExpression, String sortDirection)
        {
            int startIndex = (page - 1) * pageSize + 1;
            int endIndex = page * pageSize;

            return dataAccess.GetNotes(objectID, objectType, startIndex, endIndex, sortExpression, sortDirection);
        }

        public bool SaveDocument(int objectID, int objectType, int documentType, string documentOriginalName, string documentUniqueName)
        {
            var document = new DocumentModel
            {
                ObjectID = objectID,
                ObjectType = objectType,
                DocumentType = documentType,
                DocumentOriginalName = documentOriginalName,
                DocumentUniqueName = documentUniqueName
            };
            return dataAccess.SaveDocument(document);
        }

        public List<DocumentModel> GetDocuments(int objectID, int objectType, int page, int pageSize, String sortExpression, String sortDirection)
        {
            int startIndex = (page - 1) * pageSize + 1;
            int endIndex = page * pageSize;
            return dataAccess.GetDocuments(objectID, objectType, startIndex, endIndex, sortExpression, sortDirection);
        }

        public SubmitFormDataResponse SubmitFormDataResponse(UserDetailsModel userDetails, AddressDetailsModel currentAddress, AddressDetailsModel permanentAddress, int userID)
        {
            SubmitFormDataResponse response = new SubmitFormDataResponse();
            SessionModel userSessionInfo = GetUserSessionInfo();
            UserModel userModel = new UserModel()
            {
                UserDetails = userDetails,
                CurrentAddress = currentAddress,
                PermanentAddress = permanentAddress,
            };
            try
            {
                Business business = new Business();
                if (userID != 0)
                {
                    bool success = business.EditUserDetails(userModel, userID);
                    if (success)
                    {
                        response.EditSuccess = true;
                        response.IsAdmin = userSessionInfo.IsAdmin;
                    }

                }
                else
                {
                    bool success = business.SaveUserDetails(userModel);
                    if (success)
                    {
                        response.NewUserSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
            return response;
        }


        public bool CheckEmailExists(string email, int userID)
        {

            return dataAccess.CheckEmailExists(email, userID);
        }

        public DocumentModel GetDocument(int documentId)
        {
            return dataAccess.GetDocument(documentId);
        }

        public UserDetailsModel GetFileNameInUserDetails(int userId)
        {
            return dataAccess.GetFileNameInUserDetails(userId);
        }
    }





}
