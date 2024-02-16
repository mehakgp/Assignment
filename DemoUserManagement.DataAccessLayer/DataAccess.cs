using static DemoUserManagement.UtilityLayer.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
                        DateOfBirth = (DateTime)userDetails.DateOfBirth,
                        AadharNo = userDetails.AadharNo,
                        Email = userDetails.Email,
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
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
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

        public void SaveDocument(DocumentModel document)
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
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
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
                        University = user.University,
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
                        CountryID = (int)address.CountryID,
                        StateID = (int)address.StateID
                    };
                }
                return null;
            }

        }

        public bool NoteExists(int objectID, int objectType)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Notes WHERE ObjectID = @ObjectID AND ObjectType = @ObjectType", conn);
                cmd.Parameters.AddWithValue("@ObjectID", objectID);
                cmd.Parameters.AddWithValue("@ObjectType", objectType);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public bool DocumentExists (int objectID, int objectType)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Document WHERE ObjectID = @ObjectID AND ObjectType = @ObjectType", conn);
                cmd.Parameters.AddWithValue("@ObjectID", objectID);
                cmd.Parameters.AddWithValue("@ObjectType", objectType);
                int count = (int)cmd.ExecuteScalar();
                return count >= 0;
            }
        }

        public void InsertNote(int objectID, int objectType, String note)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Notes (ObjectID, ObjectType, Note, DateTime) VALUES (@ObjectID, @ObjectType, @Note, @DateTime)", conn);
                cmd.Parameters.AddWithValue("@ObjectID", objectID);
                cmd.Parameters.AddWithValue("@ObjectType", objectType);
                cmd.Parameters.AddWithValue("@Note", note);
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                cmd.ExecuteNonQuery();
            }

        }

        public int GetTotalCount(int objectID, int objectType)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Notes  WHERE ObjectID = @ObjectID AND ObjectType = @ObjectType", connection))
                {
                    command.Parameters.AddWithValue("@ObjectID", objectID);
                    command.Parameters.AddWithValue("@ObjectType", objectType);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public int GetTotalCountUsers()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM UserDetails", connection))
                {
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
        public DataTable GetNotes(int objectID, int objectType, int startIndex, int endIndex, String sortExpression, String sortDirection)
        {
            DataTable dtNotes = new DataTable();
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
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dtNotes);
                    }
                }
                return dtNotes;
            }
            catch (Exception ex)
            {
                LogException(ex);
                return dtNotes;
            }
        }

        public DataTable GetUsers(int startIndex, int endIndex, String sortExpression, String sortDirection)
        {
            DataTable dtUsers = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
                {
                    connection.Open();
                    string query = string.Format(@"SELECT UserID,FirstName,DateOfBirth,AadharNo,Email,PhoneNumber,UniqueFileName FROM (
                                            SELECT ROW_NUMBER() OVER (ORDER BY {0} {1}) AS RowNum, * 
                                            FROM UserDetails
                                        ) AS USerDetails 
                                        WHERE RowNum BETWEEN @StartIndex AND @EndIndex", sortExpression, sortDirection);

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@StartIndex", startIndex);
                        command.Parameters.AddWithValue("@EndIndex", endIndex);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dtUsers);

                    }
                }
                return dtUsers;
            }
            catch (Exception ex)
            {
                LogException(ex);
                return dtUsers;
            }
        }
        public List<DocumentModel> GetDocuments(int objectID, int objectType)
        {
            try
            {
                using (var context = new DemoUserManagementEntities())
                {
                    var documents = context.Documents
                        .Where(d => d.ObjectID == objectID && d.ObjectType == objectType)
                        .Select(d => new DocumentModel
                        {
                            ID = d.ID,
                            ObjectID = d.ObjectID,
                            ObjectType = d.ObjectType,
                            DocumentType = d.DocumentType,
                            DocumentOriginalName = d.DocumentOriginalName,
                            DocumentUniqueName = d.DocumentUniqueName,
                            DateTime = d.DateTime
                        })
                        .ToList();

                    return documents;
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