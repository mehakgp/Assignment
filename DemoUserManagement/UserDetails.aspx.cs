using DemoUserManagement.UtilityLayer;
using DemoUserManangement.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DemoUserManagement.ModelView.Model;


namespace DemoUserManagement
{
    public partial class UserDetials : Page
    {
        Business business = new Business();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateCountries();
                if (Request.QueryString["UserID"] != null)
                {
                    int userID = Convert.ToInt32(Request.QueryString["UserID"]);
                    UserDetailsModel userDetails = GetUserDetails(userID);
                    AddressDetailsModel currentAddress = GetAddressDetails(userID, 1);
                    AddressDetailsModel permanentAddress = GetAddressDetails(userID, 2);
                    PopulateFields(userDetails, currentAddress, permanentAddress);
                    NoteUserControl.Visible = true;
                }
                else
                {
                    NoteUserControl.Visible = false;
                }
            }
        }
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            int countryId;
            if (int.TryParse(ddlCurrentCountry.SelectedValue, out countryId))
            {
                PopulateCurrentStates(countryId);
            }
            if (int.TryParse(ddlPermanentCountry.SelectedValue, out countryId))
            {
                PopulatePermanentStates(countryId);
            }
        }

        private void PopulateCountries()
        {
            var countries = business.GetCountries();
            ddlCurrentCountry.DataSource = countries;
            ddlCurrentCountry.DataTextField = "CountryName";
            ddlCurrentCountry.DataValueField = "CountryID";
            ddlPermanentCountry.DataSource = countries;
            ddlPermanentCountry.DataTextField = "CountryName";
            ddlPermanentCountry.DataValueField = "CountryID";

            ddlCurrentCountry.DataBind();
            ddlPermanentCountry.DataBind();

            ddlCurrentCountry.Items.Insert(0, new ListItem("-- Select Country --", ""));
            ddlPermanentCountry.Items.Insert(0, new ListItem("-- Select Country --", ""));
        }

        private void PopulateCurrentStates(int countryId)
        {
            var states = business.GetStates(countryId);
            ddlCurrentState.DataSource = states;
            ddlCurrentState.DataTextField = "StateName";
            ddlCurrentState.DataValueField = "StateID";
            ddlCurrentState.DataBind();
            ddlCurrentState.Items.Insert(0, new ListItem("-- Select State --", ""));
        }

        private void PopulatePermanentStates(int countryId)
        {
            var states = business.GetStates(countryId);
            ddlPermanentState.DataSource = states;
            ddlPermanentState.DataTextField = "StateName";
            ddlPermanentState.DataValueField = "StateID";
            ddlPermanentState.DataBind();
            ddlPermanentState.Items.Insert(0, new ListItem("-- Select State --", ""));
        }

        protected void btnSubmitClick(object sender, EventArgs e)
        {
            try
            {
                UserDetailsModel userDetails = new UserDetailsModel
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    MiddleName = txtMiddleName.Text,
                    Gender = ddlGender.SelectedItem.Text,
                    DateOfBirth = string.IsNullOrEmpty(txtDateOfBirth.Text) ? null : (DateTime?)DateTime.Parse(txtDateOfBirth.Text),
                    AadharNo = txtAadharNo.Text,
                    Email = txtEmail.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    Marks10th = string.IsNullOrEmpty(txtMarks10th.Text) ? null : (decimal?)decimal.Parse(txtMarks10th.Text),
                    Board10th = ddlBoard10th.SelectedItem.Text,
                    School10th = txtSchool10th.Text,
                    YearOfCompletion10th = string.IsNullOrEmpty(txtYearOfCompletion10th.Text) ? null : (DateTime?)DateTime.Parse(txtYearOfCompletion10th.Text),
                    Marks12th = string.IsNullOrEmpty(txtMarks12th.Text) ? null : (decimal?)decimal.Parse(txtMarks12th.Text),
                    Board12th = ddlBoard12th.SelectedItem.Text,
                    School12th = txtSchool12th.Text,
                    YearOfCompletion12th = string.IsNullOrEmpty(txtYearOfCompletion12th.Text) ? null : (DateTime?)DateTime.Parse(txtYearOfCompletion12th.Text),
                    CGPA = string.IsNullOrEmpty(txtCGPA.Text) ? null : (decimal?)decimal.Parse(txtCGPA.Text),
                    University = txtUniversity.Text,
                    YearOfCompletionGraduation = string.IsNullOrEmpty(txtYearOfCompletionGraduation.Text) ? null : (DateTime?)DateTime.Parse(txtYearOfCompletionGraduation.Text),
                    Hobbies = txtHobbies.Text,
                    Comments = txtComments.Text
                };
                AddressDetailsModel currentAddress = new AddressDetailsModel
                {
                    AddressType = 1,
                    AddressLine1 = txtCurrentAddressLine1?.Text ?? "",
                    AddressLine2 = txtCurrentAddressLine2?.Text ?? "",
                    Pincode = txtCurrentPincode?.Text ?? "",
                    Country = ddlCurrentCountry?.SelectedItem?.Text ?? "",
                    State = ddlCurrentState?.SelectedItem?.Text ?? "",
                };
                AddressDetailsModel permanentAddress = new AddressDetailsModel
                {
                    AddressType = 2,
                    AddressLine1 = txtPermanentAddressLine1?.Text ?? "",
                    AddressLine2 = txtPermanentAddressLine2?.Text ?? "",
                    Pincode = txtPermanentPincode?.Text ?? "",
                    Country = ddlPermanentCountry?.SelectedItem?.Text ?? "",
                    State = ddlPermanentState?.SelectedItem?.Text ?? "",
                };

                if (!string.IsNullOrEmpty(Request.QueryString["UserID"]))
                {
                    int userID = Convert.ToInt32(Request.QueryString["UserID"]);
                    bool success=business.EditUserDetails(userDetails,currentAddress,permanentAddress,userID);
                    if (success)
                        Response.Redirect("Users.aspx");
                }
                else
                {
                    bool success = business.SaveUserDetails(userDetails, currentAddress, permanentAddress);
                    if (success)
                        Response.Redirect("Users.aspx");
                }
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
            }
        }


        private UserDetailsModel GetUserDetails(int userID)
        {
            return business.GetUserDetails(userID);
        }
        private AddressDetailsModel GetAddressDetails(int userID, int addressType)
        {
            return business.GetAddressDetails(userID, addressType);
        }
        private void PopulateFields(UserDetailsModel userDetails, AddressDetailsModel currentAddress, AddressDetailsModel permanentAddress)
        {

            txtFirstName.Text = userDetails.FirstName;
            txtLastName.Text = userDetails.LastName;
            txtMiddleName.Text = userDetails.MiddleName;
            ddlGender.SelectedValue = userDetails.Gender;
            txtDateOfBirth.Text = userDetails.DateOfBirth.HasValue ? userDetails.DateOfBirth.Value.ToString("yyyy-MM-dd") : "";
            txtAadharNo.Text = userDetails.AadharNo;
            txtEmail.Text = userDetails.Email;
            txtPhoneNumber.Text = userDetails.PhoneNumber;
            txtMarks10th.Text = userDetails.Marks10th.HasValue ? userDetails.Marks10th.Value.ToString() : "";
            ddlBoard10th.SelectedValue = userDetails.Board10th;
            txtSchool10th.Text = userDetails.School10th;
            txtYearOfCompletion10th.Text = userDetails.YearOfCompletion10th.HasValue ? userDetails.YearOfCompletion10th.Value.ToString("yyyy-MM") : "";
            txtMarks12th.Text = userDetails.Marks12th.HasValue ? userDetails.Marks12th.Value.ToString() : "";
            ddlBoard12th.SelectedValue = userDetails.Board12th;
            txtSchool12th.Text = userDetails.School12th;
            txtYearOfCompletion12th.Text = userDetails.YearOfCompletion12th.HasValue ? userDetails.YearOfCompletion12th.Value.ToString("yyyy-MM") : "";
            txtCGPA.Text = userDetails.CGPA.HasValue ? userDetails.CGPA.Value.ToString() : "";
            txtUniversity.Text = userDetails.University;
            txtYearOfCompletionGraduation.Text = userDetails.YearOfCompletionGraduation.HasValue ? userDetails.YearOfCompletionGraduation.Value.ToString("yyyy-MM") : "";
            txtHobbies.Text = userDetails.Hobbies;
            txtComments.Text = userDetails.Comments;

          
            txtCurrentAddressLine1.Text = currentAddress.AddressLine1;
            txtCurrentAddressLine2.Text = currentAddress.AddressLine2;
            txtCurrentPincode.Text = currentAddress.Pincode;
            ddlCurrentCountry.SelectedValue = currentAddress.Country;
            ddlCurrentState.SelectedValue = currentAddress.State;

            txtPermanentAddressLine1.Text = permanentAddress.AddressLine1;
            txtPermanentAddressLine2.Text = permanentAddress.AddressLine2;
            txtPermanentPincode.Text = permanentAddress.Pincode;
            ddlPermanentCountry.SelectedValue = permanentAddress.Country;
            ddlPermanentState.SelectedValue = permanentAddress.State;

        }



    }
}