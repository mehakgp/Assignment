﻿using DemoUserManagement.UtilityLayer;
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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                AddressDetailsModel currentAddress = new AddressDetailsModel();

                // Check and assign values, replacing null values with an empty string
                currentAddress.AddressType = 1;
                currentAddress.AddressLine1 = txtCurrentAddressLine1?.Text ?? "";
                currentAddress.AddressLine2 = txtCurrentAddressLine2?.Text ?? "";
                currentAddress.Pincode = txtCurrentPincode?.Text ?? "";
                currentAddress.Country = ddlCurrentCountry?.SelectedItem?.Text ?? "";
                currentAddress.State = ddlCurrentState?.SelectedItem?.Text ?? "";

                AddressDetailsModel permanentAddress = new AddressDetailsModel();

                // Check and assign values, replacing null values with an empty string
                permanentAddress.AddressType = 2;
                permanentAddress.AddressLine1 = txtPermanentAddressLine1?.Text ?? "";
                permanentAddress.AddressLine2 = txtPermanentAddressLine2?.Text ?? "";
                permanentAddress.Pincode = txtPermanentPincode?.Text ?? "";
                permanentAddress.Country = ddlPermanentCountry?.SelectedItem?.Text ?? "";
                permanentAddress.State = ddlPermanentState?.SelectedItem?.Text ?? "";



                Business business = new Business();
                bool success = business.SaveUserDetails(userDetails, currentAddress, permanentAddress);

                if (success)
                {
                    Response.Redirect("Users.aspx");
                }

            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
            }
        }



    }
}