<%@ Page Title="User Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDetails2.aspx.cs" Inherits="DemoUserManagement.UserDetails2" %>

<%@ Register Src="~/NoteUserControl.ascx" TagPrefix="uc1" TagName="NoteUserControl" %>
<%@ Register Src="~/DocumentUserControl.ascx" TagPrefix="uc2" TagName="DocumentUserControl" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="Scripts/DemoUserManagement2.js"></script>
    <asp:HiddenField ID="hdnUserSessionInfo" runat="server" ClientIDMode="Static" />
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
                <div class="col-md-4 >
                    <label for="txtFirstName">First Name: *</label>
                    <input type="text" id="txtFirstName" cssClass="form-control" />
                </div>
                <div class="col-md-4">
                    <label for="txtMiddleName">Middle Name:</label>
                    <input type="text" id="txtMiddleName" cssClass="form-control" />

                </div>
                <div class="col-md-4">
                    <label for="txtLastName">Last Name:</label>
                    <input type="text" id="txtLastName" cssClass="form-control" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <label for="ddlGender">Gender:</label>
                    <select id="ddlGender" class="form-control">
                        <option value="">Select Gender</option>
                        <option value="Male">Male</option>
                        <option value="Female">Female</option>
                        <option value="Other">Other</option>
                    </select>

                </div>
                <div class="col-md-4">
                    <label for="txtDateOfBirth">Date of Birth: *</label>
                    <input id="txtDateOfBirth" class="form-control" type="date" />
                </div>
                <div class="col-md-4">
                    <label for="txtAadharNo">Aadhar No: *</label>
                    <input type="number" id="txtAadharNo" cssclass="form-control" />
                </div>
            </div>

            <h2>Contact Details</h2>
            <div class="row">
                <div class="col-md-4">
                    <label for="txtEmail">Email: *</label>
                    <input type="email" id="txtEmail" cssclass="form-control" />
                </div>
                <div class="col-md-4">
                    <label for="txtPassword">Password: *</label>
                    <input type="text" id="txtPassword" cssclass="form-control" />
                </div>
                <div class="col-md-4">
                    <label for="txtPhoneNumber">Phone Number: *</label>
                    <input type="number" id="txtPhoneNumber" cssclass="form-control" />
                </div>
            </div>

            <h2>Address Details</h2>
            <h4>Current Address</h4>
            <div class="row">
                <div class="col-md-4">
                    <label for="txtCurrentAddressLine1">Address Line 1: *</label>
                    <input type="text" id="txtCurrentAddressLine1" cssclass="form-control" />
                </div>
                <div class="col-md-4">
                    <label for="txtCurrentAddressLine2">Address Line 2:</label>
                    <input type="text" id="txtCurrentAddressLine2" cssclass="form-control" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <label for="ddlCurrentCountry">Country: *</label>
                    <select id="ddlCurrentCountry" class="form-control">
                        <%-- <option value="">Select Country</option>--%>
                    </select>

                </div>
                <div class="col-md-4">
                    <label for="ddlCurrentState">State: *</label>
                    <select id="ddlCurrentState" cssclass="form-control">
                    </select>
                </div>
                <div class="col-md-4">
                    <label for="txtCurrentPincode">Pincode: *</label>
                    <input type="number" id="txtCurrentPincode" cssclass="form-control" />
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
                    <input type="text" id="txtPermanentAddressLine1" cssclass="form-control" />
                </div>
                <div class="col-md-4">
                    <label for="txtPermanentAddressLine2">Address Line 2:</label>
                    <input type="text" id="txtPermanentAddressLine2" cssclass="form-control" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <label for="ddlPermanentCountry">Country: *</label>
                    <select id="ddlPermanentCountry" cssClass="form-control">
                        <%-- <option value="">Select Country</option>--%>
                    </select>

                </div>
                <div class="col-md-4">
                    <label for="ddlPermanentState">State: *</label>
                    <select id="ddlPermanentState" cssClass="form-control">
                    </select>

                </div>
                <div class="col-md-4">
                    <label for="txtPermanentPincode">Pincode: *</label>
                    <input type="text" id="txtPermanentPincode" cssclass="form-control" />
                </div>
            </div>
            <h2>Academic Details</h2>
            <h4>Class 10</h4>
            <div class="row">
                <div class="col-md-3">
                    <label for="txtMarks10th">Percentage: *</label>
                    <input type="number" id="txtMarks10th" cssClass="form-control" />
                </div>
                <div class="col-md-3">
                    <label for="ddlBoard10th">Board:</label>
                    <select id="ddlBoard10th" class="form-control" clientidmode="Static">
                        <option value="">Select Board</option>
                        <option value="CBSE">CBSE</option>
                        <option value="ICSE">ICSE</option>
                    </select>

                </div>
                <div class="col-md-3">
                    <label for="txtSchool10th">School:</label>
                    <input type="text" id="txtSchool10th" cssclass="form-control" />
                </div>
                <div class="col-md-3">
                    <label for="txtYearOfCompletion10th">Year of Completion:</label>
                    <input id="txtYearOfCompletion10th" cssClass="form-control" type="month" />

                </div>
            </div>

            <h4>Class 12</h4>
            <div class="row">
                <div class="col-md-3">
                    <label for="txtMarks12th">Percentage: *</label>
                    <input type="number" id="txtMarks12th" cssclass="form-control" />
                </div>
                <div class="col-md-3">
                    <label for="ddlBoard12th">Board:</label>
                    <select id="ddlBoard12th" class="form-control" clientidmode="Static">
                        <option value="">Select Board</option>
                        <option value="CBSE">CBSE</option>
                        <option value="ICSE">ICSE</option>
                    </select>
                </div>
                <div class="col-md-3">
                    <label for="txtSchool12th">School:</label>
                    <input type="text" id="txtSchool12th" cssclass="form-control" />
                </div>
                <div class="col-md-3">
                    <label for="txtYearOfCompletion12th">Year of Completion:</label>
                    <input id="txtYearOfCompletion12th" class="form-control" type="month" />
                </div>
            </div>

            <h4>Graduation</h4>
            <div class="row">
                <div class="col-md-3">
                    <label for="txtCGPA">CGPA: *</label>
                    <input type="number" id="txtCGPA" cssclass="form-control" />
                </div>
                <div class="col-md-3">
                    <label for="txtUniversity">University:</label>
                    <input type="text" id="txtUniversity" cssclass="form-control" />
                </div>
                <div class="col-md-3">
                    <label for="txtYearOfCompletionGraduation">Year of Completion:</label>
                    <input id="txtYearOfCompletionGraduation" class="form-control" type="month" />
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
                    <input type="text" id="txtHobbies" cssclass="form-control" textmode="MultiLine" rows="2" />
                </div>
                <div class="col-md-4 form-group">
                    <label for="txtComments">Comments/ Feedback:</label>
                    <input type="text" id="txtComments" cssclass="form-control" textmode="MultiLine" rows="2" />
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
