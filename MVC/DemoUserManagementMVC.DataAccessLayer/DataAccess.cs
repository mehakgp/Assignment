using static DemoUserManagementMVC.UtilityLayer.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DemoUserManagementMVC.ModelView;
using DemoUserManagementMVC.DataAccessLayer;


namespace DemoUserManagementMVC.DataAccessLayer
{
    public class DataAccess
    {
        public List<CountryModel> GetCountries()
        {
            try
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
            catch (Exception ex)
            {
                LogException(ex);
                return new List<CountryModel>();
            }
           
        }

        public List<StateModel> GetStates(int countryId)
        {
            try
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
           catch(Exception ex)
            {
                LogException (ex);
                return new List<StateModel>();
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
                        DateOfBirth = (DateTime)userDetails.DateOfBirth,
                        AadharNo = userDetails.AadharNo,
                        Email = userDetails.Email,
                        Password=userDetails.Password,
                        PhoneNumber = userDetails.PhoneNumber,
                        Marks10th = userDetails.Marks10th,
                        Board10th = userDetails.Board10th,
                        School10th = userDetails.School10th,
                        YearOfCompletion10th = userDetails.YearOfCompletion10th,
                        Marks12th = userDetails.Marks12th,
                        Board12th = userDetails.Board12th,
                        School12th = userDetails.School12th,
                        YearOfCompletion12th = userDetails.YearOfCompletion12th,
                        CGPA = userDetails.CGPA,
                        University = userDetails.University,
                        YearOfCompletionGraduation = userDetails.YearOfCompletionGraduation,
                        Hobbies = userDetails.Hobbies,
                        Comments = userDetails.Comments,
                        OriginalFileName = userDetails.OriginalFileName,
                        UniqueFileName = userDetails.UniqueFileName,

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
                        CountryID = currentAddress.CountryID,
                        StateID = currentAddress.StateID
                    };
                    context.AddressDetails.Add(current);

                    var permanent = new AddressDetail
                    {
                        UserID = user.UserID,
                        AddressType = permanentAddress.AddressType,
                        AddressLine1 = permanentAddress.AddressLine1,
                        AddressLine2 = permanentAddress.AddressLine2,
                        Pincode = permanentAddress.Pincode,
                        CountryID = permanentAddress.CountryID,
                        StateID = permanentAddress.StateID
                    };
                    context.AddressDetails.Add(permanent);

                    context.SaveChanges();
                    AssignDefaultRole(user.UserID);
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        
        }

        public void AssignDefaultRole(int userID)
        {
            try
            {
                using (var context = new DemoUserManagementEntities())
                {
                    var defaultRoles = context.Roles.Where(r => r.isDefault == 1).ToList();
                    foreach (var role in defaultRoles)
                    {
                        var userRole = new UserRole
                        {
                            UserID = userID,
                            RoleID = role.RoleID
                        };
                        context.UserRoles.Add(userRole);
                    }

                    context.SaveChanges();
                }
            }
              catch(Exception ex)
            {
                LogException (ex);
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
                        user.Password = userDetails.Password;
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
                        user.OriginalFileName= userDetails.OriginalFileName;
                        user.UniqueFileName= userDetails.UniqueFileName;


                        var current = context.AddressDetails.FirstOrDefault(a => a.UserID == userID && a.AddressType == currentAddress.AddressType);
                        if (current != null)
                        {
                            current.AddressLine1 = currentAddress.AddressLine1;
                            current.AddressLine2 = currentAddress.AddressLine2;
                            current.Pincode = currentAddress.Pincode;
                            current.CountryID = currentAddress.CountryID;
                            current.StateID = currentAddress.StateID;
                        }

                        var permanent = context.AddressDetails.FirstOrDefault(a => a.UserID == userID && a.AddressType == permanentAddress.AddressType);
                        if (permanent != null)
                        {
                            permanent.AddressLine1 = permanentAddress.AddressLine1;
                            permanent.AddressLine2 = permanentAddress.AddressLine2;
                            permanent.Pincode = permanentAddress.Pincode;
                            permanent.CountryID = permanentAddress.CountryID;
                            permanent.StateID = permanentAddress.StateID;
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
                LogException(ex);
                return false;
            }
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
                LogException(ex);
                return false;
            }
        }

        public bool SaveDocument(DocumentModel document)
        {
            try
            {
                using (var context = new DemoUserManagementEntities())
                {
                    var doc = new Document
                    {
                        ObjectID = document.ObjectID,
                        ObjectType = document.ObjectType,
                        DocumentType = document.DocumentType,
                        DocumentOriginalName = document.DocumentOriginalName,
                        DocumentUniqueName = document.DocumentUniqueName,
                        DateTime = DateTime.Now,
                    };
                    context.Documents.Add(doc);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }

        }

        public UserDetailsModel GetUserDetails(int userID)
        {
            try
            {
                using (var context = new DemoUserManagementEntities())
                {
                    var user = context.UserDetails.FirstOrDefault(u => u.UserID == userID);
                    if (user != null)
                    {
                        return new UserDetailsModel
                        {
                            UserID = user.UserID,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            MiddleName = user.MiddleName,
                            Gender = user.Gender,
                            DateOfBirth =user.DateOfBirth,
                            AadharNo = user.AadharNo,
                            Email = user.Email,
                            Password = user.Password,
                            PhoneNumber = user.PhoneNumber,
                            Marks10th = user.Marks10th,
                            Board10th = user.Board10th,
                            School10th = user.School10th,
                            YearOfCompletion10th = user.YearOfCompletion10th != null ? (DateTime)user.YearOfCompletion10th : DateTime.MinValue,
                            Marks12th = user.Marks12th,
                            Board12th = user.Board12th,
                            School12th = user.School12th,
                            YearOfCompletion12th =user.YearOfCompletion12th!=null? (DateTime)user.YearOfCompletion12th:DateTime.MinValue,   
                            CGPA = user.CGPA,
                            University = user.University,
                            YearOfCompletionGraduation = user.YearOfCompletionGraduation != null ? (DateTime)user.YearOfCompletionGraduation : DateTime.MinValue,
                            Hobbies = user.Hobbies,
                            Comments = user.Comments,

                        };
                    }
                    return null;
                }
            }
            catch(Exception ex)
            {
                LogException(ex);
                return null;
            }
           
        }

        public AddressDetailsModel GetAddressDetails(int userID, int addressType)
        {

            try
            {
                using (var context = new DemoUserManagementEntities())
                {
                    var address = context.AddressDetails.FirstOrDefault(a => a.UserID == userID && a.AddressType == addressType);
                    if (address != null)
                    {
                        return new AddressDetailsModel
                        {
                            AddressID = address.AddressID,
                            UserID = (int)address.UserID,
                            AddressType = (int)address.AddressType,
                            AddressLine1 = address.AddressLine1,
                            AddressLine2 = address.AddressLine2,
                            Pincode = address.Pincode,
                            CountryID = (int)address.CountryID,
                            StateID = (int)address.StateID
                        };
                    }
                    return null;
                }
            }
          catch(Exception ex)
            {
                LogException (ex);
                return null;
            }

        }
   


        public bool InsertNote(int objectID, int objectType, string note)
        {
            try
            {
                using (var context = new DemoUserManagementEntities())
                {
                    var newNote = new Note
                    {
                        ObjectID = objectID,
                        ObjectType = objectType,
                        Note1 = note,
                        DateTime = DateTime.Now
                    };

                    context.Notes.Add(newNote);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogException (ex);
                return false;
            }
        
        }

        public int GetTotalCountNote(int objectID, int objectType)
        {
            try
            {
                using (var context = new DemoUserManagementEntities())
                {
                    return context.Notes
                        .Where(n => n.ObjectID == objectID && n.ObjectType == objectType)
                        .Count();
                }
            }
            catch(Exception ex)
            {
                LogException(ex);
                return 0;
            }
           
        }
        public int GetTotalCountDocument(int objectID, int objectType)
        {
            try
            {
                using (var context = new DemoUserManagementEntities())
                {
                    return context.Documents
                        .Where(n => n.ObjectID == objectID && n.ObjectType == objectType)
                        .Count();
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return 0;
            }

        }

        public int GetTotalCountUsers()
        {
            try
            {
                using (var context = new DemoUserManagementEntities())
                {
                    return context.UserDetails.Count();
                }
            }
            catch(Exception e)
            {
                LogException(e); return 0;
            }
        }

       
        public List<NoteModel> GetNotes(int objectID, int objectType, int startIndex, int endIndex, String sortExpression, String sortDirection)
        {
            List<NoteModel> notes = new List<NoteModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
                {
                    connection.Open();
                    string query = string.Format(@"SELECT * FROM (
                        SELECT ROW_NUMBER() OVER (ORDER BY {0} {1}) AS RowNum, * 
                        FROM Notes
                        WHERE ObjectID = @ObjectID AND ObjectType = @ObjectType
                    ) AS Notes 
                    WHERE RowNum BETWEEN @StartIndex AND @EndIndex", sortExpression, sortDirection);

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartIndex", startIndex);
                        command.Parameters.AddWithValue("@EndIndex", endIndex);
                        command.Parameters.AddWithValue("@ObjectID", objectID);
                        command.Parameters.AddWithValue("@ObjectType", objectType);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NoteModel note = new NoteModel
                                {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    ObjectID = Convert.ToInt32(reader["ObjectID"]),
                                    ObjectType = Convert.ToInt32(reader["ObjectType"]),
                                    Note = reader["Note"].ToString(),
                                    DateTime = Convert.ToDateTime(reader["DateTime"])
                                };
                                notes.Add(note);
                            }
                        }
                    }
                }
                return notes;
            }
            catch (Exception ex)
            {
                LogException(ex);
                return notes;
            }
        }




        public List<UserListModel> GetUsers(int startIndex, int endIndex, string sortExpression, string sortDirection)
            {
                List<UserListModel> users = new List<UserListModel>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
                    {
                        connection.Open();
                        string query = string.Format(@"SELECT UserID,FirstName,DateOfBirth,AadharNo,Email,PhoneNumber FROM (
                                                  SELECT ROW_NUMBER() OVER (ORDER BY {0} {1}) AS RowNum, * 
                                                  FROM UserDetails
                                              ) AS UserDetails 
                                              WHERE RowNum BETWEEN @StartIndex AND @EndIndex", sortExpression, sortDirection);

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@StartIndex", startIndex);
                            command.Parameters.AddWithValue("@EndIndex", endIndex);
                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            DataTable dtUsers = new DataTable();
                            adapter.Fill(dtUsers);

                            foreach (DataRow row in dtUsers.Rows)
                            {
                                UserListModel user = new UserListModel
                                {
                                    UserID = Convert.ToInt32(row["UserID"]),
                                    FirstName = row["FirstName"].ToString(),
                                    DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                                    AadharNo = row["AadharNo"].ToString(),
                                    Email = row["Email"].ToString(),
                                    PhoneNumber = row["PhoneNumber"].ToString()
                                };
                                users.Add(user);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogException(ex);
                }
                return users;
            }
        

        public List<DocumentModel> GetDocuments(int objectID, int objectType, int startIndex, int endIndex, String sortExpression, String sortDirection)
        {
            List<DocumentModel> documents=new List<DocumentModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
                {
                    connection.Open();
                    string query = string.Format(@"SELECT * FROM (
                        SELECT ROW_NUMBER() OVER (ORDER BY {0} {1}) AS RowNum, * 
                        FROM Document
                        WHERE ObjectID = @ObjectID AND ObjectType = @ObjectType
                    ) AS Document 
                    WHERE RowNum BETWEEN @StartIndex AND @EndIndex", sortExpression, sortDirection);

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartIndex", startIndex);
                        command.Parameters.AddWithValue("@EndIndex", endIndex);
                        command.Parameters.AddWithValue("@ObjectID", objectID);
                        command.Parameters.AddWithValue("@ObjectType", objectType);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DocumentModel doc = new DocumentModel
                                {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    ObjectID = Convert.ToInt32(reader["ObjectID"]),
                                    ObjectType = Convert.ToInt32(reader["ObjectType"]),
                                    DocumentType = Convert.ToInt32(reader["DocumentType"]),
                                    DocumentOriginalName = reader["DocumentOriginalName"].ToString(),
                                    DocumentUniqueName = reader["DocumentUniqueName"].ToString(),
                                    DateTime = Convert.ToDateTime(reader["DateTime"])
                                };
                                documents.Add(doc);
                            }
                        }
                    }
                }
                return documents;
            }
               
            
            catch (Exception ex)
            {
                LogException(ex);
                return documents;
            }
        }

        public int GetUserByEmailAndPassword(string email, string password)
        
        {
            try
            {
                using (var context = new DemoUserManagementEntities())
                {
                    var user = context.UserDetails.FirstOrDefault(u => u.Email == email);
                    if (user != null && user.Password == password)
                    {
                        return user.UserID;
                    }
                    return -1;
                }
            }
           catch(Exception ex)
            {
                LogException (ex);
                return -1;
            }
        }

        public bool CheckIfUserIsAdmin(int userID)
        {
            try
            {
                using (var context = new DemoUserManagementEntities())
                {
                    var userRoles = context.UserRoles.Where(ur => ur.UserID == userID);
                    foreach (var userRole in userRoles)
                    {
                        var role = context.Roles.FirstOrDefault(r => r.RoleID == userRole.RoleID);
                        if (role != null && role.isAdmin == 1)
                        {
                            return true;
                        }
                    }
                }
                return false;

            }
            catch(Exception ex)
            {
                LogException(ex);
                return false;
            }
            
        }
        public bool CheckEmailExists(string email, int userID)
        {
            using (var context = new DemoUserManagementEntities())
            {
                if (userID == 0)
                {
                    return context.UserDetails.Any(u => u.Email == email);
                }
                else
                {
                    return context.UserDetails.Any(u => u.Email == email && u.UserID != userID);
                }
            }
        }

        public DocumentModel GetDocument(int documentId)
        {
            try
            {
                using (var context = new DemoUserManagementEntities())
                {
                    var document = context.Documents.FirstOrDefault(d => d.ID == documentId);
                    return new DocumentModel
                    {
                        DocumentOriginalName = document.DocumentOriginalName,
                        DocumentUniqueName = document.DocumentUniqueName,
                    };
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return null;
            }
           
        }

        public UserDetailsModel GetFileNameInUserDetails(int userId)
        {
            try
            {
                using (var context = new DemoUserManagementEntities())
                {
                    var user = context.UserDetails.FirstOrDefault(u => u.UserID == userId);
                    return new UserDetailsModel
                    {
                        OriginalFileName = user.OriginalFileName,
                        UniqueFileName = user.UniqueFileName,

                    };
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return null;
            }
           
        }
    }

}