<%@ Page Title="User Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDetails2.aspx.cs" Inherits="DemoUserManagement.UserDetails2" %>

<%@ Register Src="~/NoteUserControl.ascx" TagPrefix="uc1" TagName="NoteUserControl" %>
<%@ Register Src="~/DocumentUserControl.ascx" TagPrefix="uc2" TagName="DocumentUserControl" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="Scripts/DemoUserManagement_UserDetails2.js"></script>
    <style>
        h1 {
            text-align: center;
            color: rgba(33,37,41);
            padding-bottom: 10px;
        }

        h2 {
            color: rgba(33,37,41);
            border-bottom: 2px solid rgba(33,37,41);
            padding-bottom: 10px;
        }

        h4 {
            color: rgba(33,37,41);
            font-style: italic;
        }

        .row {
            margin-bottom: 20px;
        }

        label {
            font-weight: bold;
            color: rgba(33,37,41);
        }


        .btn {
            background-color: rgba(33,37,41);
            color: #fff;
            border: none;
            border-radius: 3px;
            padding: 8px 20px;
            cursor: pointer;
        }


        .btn-secondary {
            background-color: #6c757d;
        }


        .form-check-input {
            margin-top: 6px;
        }
    </style>
    <main>
        <div class="container">
            <h1>USER DETAILS FORM</h1>
            <h2>Personal Details</h2>
            <div class="row">
                <div class="col-md-4" >
                    <label for="txtFirstName">First Name: *</label>
                    <input type="text" id="txtFirstName" class="form-control validate-input"  data-field="FirstName" />
                </div>
                <div class="col-md-4">
                    <label for="txtMiddleName">Middle Name:</label>
                    <input type="text" id="txtMiddleName" class="form-control"  data-field="MiddleName"/>

                </div>
                <div class="col-md-4">
                    <label for="txtLastName">Last Name:</label>
                    <input type="text" id="txtLastName" class="form-control"  data-field="LastName" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <label for="ddlGender">Gender: *</label>
                    <select id="ddlGender" class="form-control validate-input"  data-field="Gender">
                        <option value="">Select Gender</option>
                        <option value="Male">Male</option>
                        <option value="Female">Female</option>
                        <option value="Other">Other</option>
                    </select>

                </div>
                <div class="col-md-4">
                    <label for="txtDateOfBirth">Date of Birth: *</label>
                    <input id="txtDateOfBirth" class="form-control validate-input" type="date" data-field="DateOfBirth" />
                </div>
                <div class="col-md-4">
                    <label for="txtAadharNo">Aadhar No: *</label>
                    <input type="text" id="txtAadharNo" class="form-control validate-input"  data-field="AadharNo" />
                </div>
            </div>

            <h2>Contact Details</h2>
            <div class="row">
                <div class="col-md-4">
                    <label for="txtEmail">Email: *</label>
                    <input type="text" id="txtEmail" class="form-control validate-input"  data-field="Email"/>
                </div>
                <div class="col-md-4">
                    <label for="txtPassword">Password: *</label>
                    <input type="text" id="txtPassword" class="form-control validate-input" data-field="Password" />
                </div>
                <div class="col-md-4">
                    <label for="txtPhoneNumber">Phone Number: *</label>
                    <input type="text" id="txtPhoneNumber" class="form-control validate-input" data-field="PhoneNumber" />
                </div>
            </div>

            <h2>Address Details</h2>
            <h4>Current Address</h4>
            <div class="row">
                <div class="col-md-4">
                    <label for="txtCurrentAddressLine1">Address Line 1: *</label>
                    <input type="text" id="txtCurrentAddressLine1" class="form-control validate-input"  data-field="CurrentAddressLine1" />
                </div>
                <div class="col-md-4">
                    <label for="txtCurrentAddressLine2">Address Line 2:</label>
                    <input type="text" id="txtCurrentAddressLine2" class="form-control" data-field="CurrentAddressLine2"  />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <label for="ddlCurrentCountry">Country: *</label>
                    <select id="ddlCurrentCountry" class="form-control validate-input"  data-field="CurrentCountry">
                        <option value="">Select Country</option>
                    </select>

                </div>
                <div class="col-md-4">
                    <label for="ddlCurrentState">State: *</label>
                    <select id="ddlCurrentState" class="form-control validate-input" data-field="CurrentState" >
                        <option value="">Select State</option>
                    </select>
                </div>
                <div class="col-md-4">
                    <label for="txtCurrentPincode">Pincode: *</label>
                    <input type="text" id="txtCurrentPincode" class="form-control validate-input" data-field="CurrentPincode" />
                </div>
            </div>

            <h4>Permanent Address</h4>
            <div class="form-check">
                <input type="checkbox" class="form-check-input" id="chkSameAsCurrent" onclick="copyCurrentAddress()">
                <label class="form-check-label" for="chkSameAsCurrent">Same as Current Address</label>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <label for="txtPermanentAddressLine1">Address Line 1: *</label>
                    <input type="text" id="txtPermanentAddressLine1" class="form-control validate-input" data-field="PermanentAddressLine1"/>
                </div>
                <div class="col-md-4">
                    <label for="txtPermanentAddressLine2">Address Line 2:</label>
                    <input type="text" id="txtPermanentAddressLine2" class="form-control" data-field="PermanentAddressLine2" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <label for="ddlPermanentCountry">Country: *</label>
                    <select id="ddlPermanentCountry" class="form-control validate-input"  data-field="PermanentCountry">
                        <option value="">Select Country</option>
                    </select>

                </div>
                <div class="col-md-4">
                    <label for="ddlPermanentState">State: *</label>
                    <select id="ddlPermanentState" class="form-control validate-input" data-field="PermanentState">
                        <option value="">Select State</option>
                    </select>

                </div>
                <div class="col-md-4">
                    <label for="txtPermanentPincode">Pincode: *</label>
                    <input type="text" id="txtPermanentPincode" class="form-control validate-input"  data-field="PermanentPincode"  />
                </div>
            </div>
            <h2>Academic Details</h2>
            <h4>Class 10</h4>
            <div class="row">
                <div class="col-md-3">
                    <label for="txtMarks10th">Percentage: *</label>
                    <input type="text" id="txtMarks10th" class="form-control validate-input"  data-field="Marks10th"/>
                </div>
                <div class="col-md-3">
                    <label for="ddlBoard10th">Board:</label>
                    <select id="ddlBoard10th" class="form-control" clientidmode="Static" data-field="Board10th">
                        <option value="">Select Board</option>
                        <option value="CBSE">CBSE</option>
                        <option value="ICSE">ICSE</option>
                    </select>

                </div>
                <div class="col-md-3">
                    <label for="txtSchool10th">School:</label>
                    <input type="text" id="txtSchool10th" class="form-control" data-field="School10th" />
                </div>
                <div class="col-md-3">
                    <label for="txtYearOfCompletion10th">Year of Completion:</label>
                    <input id="txtYearOfCompletion10th" class="form-control" type="date"  data-field="YearOfCompletion10th" />

                </div>
            </div>

            <h4>Class 12</h4>
            <div class="row">
                <div class="col-md-3">
                    <label for="txtMarks12th">Percentage: *</label>
                    <input type="text" id="txtMarks12th" class="form-control validate-input"  data-field="Marks12th"/>
                </div>
                <div class="col-md-3">
                    <label for="ddlBoard12th">Board:</label>
                    <select id="ddlBoard12th" class="form-control" clientidmode="Static" data-field="Board12th">
                        <option value="">Select Board</option>
                        <option value="CBSE">CBSE</option>
                        <option value="ICSE">ICSE</option>
                    </select>
                </div>
                <div class="col-md-3">
                    <label for="txtSchool12th">School:</label>
                    <input type="text" id="txtSchool12th" class="form-control" data-field="School12th" />
                </div>
                <div class="col-md-3">
                    <label for="txtYearOfCompletion12th">Year of Completion:</label>
                    <input id="txtYearOfCompletion12th" class="form-control" type="date"   data-field="YearOfCompletion12th"/>
                </div>
            </div>

            <h4>Graduation</h4>
            <div class="row">
                <div class="col-md-3">
                    <label for="txtCGPA">CGPA: *</label>
                    <input type="text" id="txtCGPA" class="form-control validate-input"  data-field="CGPA" />
                </div>
                <div class="col-md-3">
                    <label for="txtUniversity">University:</label>
                    <input type="text" id="txtUniversity" class="form-control"  data-field="University" />
                </div>
                <div class="col-md-3">
                    <label for="txtYearOfCompletionGraduation">Year of Completion:</label>
                    <input id="txtYearOfCompletionGraduation" class="form-control" type="date"  data-field="YearOfCompletionGraduation"/>
                </div>
                <div class="col-md-3">
                    <label for="resume">Upload your Resume:</label>
                    <input type="file" id="resume" class="form-control" />

                </div>
            </div>
            <h2>Other Details</h2>
            <div class="row">
                <div class="col-md-4">
                    <label for="txtHobbies">Hobbies:</label>
                    <input type="text" id="txtHobbies" class="form-control" textmode="MultiLine" rows="2"  data-field="Hobbies" />
                </div>
                <div class="col-md-4 form-group">
                    <label for="txtComments">Comments/ Feedback:</label>
                    <input type="text" id="txtComments" class="form-control" textmode="MultiLine" rows="2"  data-field="Comments" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <uc1:NoteUserControl runat="server" ID="NoteUserControl" />
                </div>
                <div class="col-md-6">
                    <uc2:DocumentUserControl runat="server" ID="DocumentUserControl" />
                </div>
            </div>


        </div>

        <div class="row mt-3">
            <div class="col-md-12 text-center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClientClick="return validateForm();" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-secondary ml-2" OnClientClick="resetForm();" />
            </div>
        </div>
    </main>

</asp:Content>
