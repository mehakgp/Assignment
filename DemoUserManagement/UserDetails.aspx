<%@ Page Title="User Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="DemoUserManagement.UserDetails" %>

<%@ Register Src="~/NoteUserControl.ascx" TagPrefix="uc1" TagName="NoteUserControl" %>
<%@ Register Src="~/DocumentUserControl.ascx" TagPrefix="uc2" TagName="DocumentUserControl" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="Scripts/DemoUserManagement_UserDetails.js"></script>

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
                <div class="col-md-4">
                    <label for="txtFirstName">First Name: *</label>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="txtMiddleName">Middle Name:</label>
                    <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="txtLastName">Last Name:</label>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <label for="ddlGender">Gender:</label>
                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control" ClientIDMode="Static">
                        <asp:ListItem Text="Select Gender" Value=""></asp:ListItem>
                        <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <label for="txtDateOfBirth">Date of Birth: *</label>
                    <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="form-control" TextMode="Date" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="txtAadharNo">Aadhar No: *</label>
                    <asp:TextBox ID="txtAadharNo" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>

            <h2>Contact Details</h2>
            <div class="row">
                <div class="col-md-4">
                    <label for="txtEmail">Email: *</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="txtPassword">Password: *</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="txtPhoneNumber">Phone Number: *</label>
                    <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>

            <h2>Address Details</h2>
            <h4>Current Address</h4>
            <div class="row">
                <div class="col-md-4">
                    <label for="txtCurrentAddressLine1">Address Line 1: *</label>
                    <asp:TextBox ID="txtCurrentAddressLine1" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="txtCurrentAddressLine2">Address Line 2:</label>
                    <asp:TextBox ID="txtCurrentAddressLine2" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <label for="ddlCurrentCountry">Country: *</label>
                    <asp:DropDownList ID="ddlCurrentCountry" runat="server" CssClass="form-control" ClientIDMode="Static"
                        AutoPostBack="true" AppendDataBoundItems="true" >
                    </asp:DropDownList>


                </div>
                <div class="col-md-4">
                    <label for="ddlCurrentState">State: *</label>
                    <asp:DropDownList ID="ddlCurrentState" runat="server" CssClass="form-control" ClientIDMode="Static"
                        AutoPostBack="true" AppendDataBoundItems="true">
                    </asp:DropDownList>

                </div>
                <div class="col-md-4">
                    <label for="txtCurrentPincode">Pincode: *</label>
                    <asp:TextBox ID="txtCurrentPincode" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
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
                    <asp:TextBox ID="txtPermanentAddressLine1" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="txtPermanentAddressLine2">Address Line 2:</label>
                    <asp:TextBox ID="txtPermanentAddressLine2" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <label for="ddlPermanentCountry">Country: *</label>
                    <asp:DropDownList ID="ddlPermanentCountry" runat="server" CssClass="form-control" ClientIDMode="Static"
                        AutoPostBack="true" AppendDataBoundItems="true">
                    </asp:DropDownList>

                </div>
                <div class="col-md-4">
                    <label for="ddlPermanentState">State: *</label>
                    <asp:DropDownList ID="ddlPermanentState" runat="server" CssClass="form-control" ClientIDMode="Static"
                        AutoPostBack="true" AppendDataBoundItems="true">
                    </asp:DropDownList>

                </div>
                <div class="col-md-4">
                    <label for="txtPermanentPincode">Pincode: *</label>
                    <asp:TextBox ID="txtPermanentPincode" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>
            <h2>Academic Details</h2>
            <h4>Class 10</h4>
            <div class="row">
                <div class="col-md-3">
                    <label for="txtMarks10th">Percentage: *</label>
                    <asp:TextBox ID="txtMarks10th" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label for="ddlBoard10th">Board:</label>
                    <asp:DropDownList ID="ddlBoard10th" runat="server" CssClass="form-control" ClientIDMode="Static">
                        <asp:ListItem Text="Select Board" Value=""></asp:ListItem>
                        <asp:ListItem Text="CBSE" Value="CBSE"></asp:ListItem>
                        <asp:ListItem Text="ICSE" Value="ICSE"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <label for="txtSchool10th">School:</label>
                    <asp:TextBox ID="txtSchool10th" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label for="txtYearOfCompletion10th">Year of Completion:</label>
                    <asp:TextBox ID="txtYearOfCompletion10th" runat="server" CssClass="form-control" ClientIDMode="Static" TextMode="Month"></asp:TextBox>
                </div>
            </div>

            <h4>Class 12</h4>
            <div class="row">
                <div class="col-md-3">
                    <label for="txtMarks12th">Percentage: *</label>
                    <asp:TextBox ID="txtMarks12th" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label for="ddlBoard12th">Board:</label>
                    <asp:DropDownList ID="ddlBoard12th" runat="server" CssClass="form-control" ClientIDMode="Static">
                        <asp:ListItem Text="Select Board" Value=""></asp:ListItem>
                        <asp:ListItem Text="CBSE" Value="CBSE"></asp:ListItem>
                        <asp:ListItem Text="ICSE" Value="ICSE"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <label for="txtSchool12th">School:</label>
                    <asp:TextBox ID="txtSchool12th" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label for="txtYearOfCompletion12th">Year of Completion:</label>
                    <asp:TextBox ID="txtYearOfCompletion12th" runat="server" CssClass="form-control" ClientIDMode="Static" TextMode="Month"></asp:TextBox>
                </div>
            </div>

            <h4>Graduation</h4>
            <div class="row">
                <div class="col-md-3">
                    <label for="txtCGPA">CGPA: *</label>
                    <asp:TextBox ID="txtCGPA" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label for="txtUniversity">University:</label>
                    <asp:TextBox ID="txtUniversity" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label for="txtYearOfCompletionGraduation">Year of Completion:</label>
                    <asp:TextBox ID="txtYearOfCompletionGraduation" runat="server" CssClass="form-control" ClientIDMode="Static" TextMode="Month"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label for="resume">Upload your Resume:</label>
                    <asp:FileUpload ID="resume" runat="server" CssClass="form-control" ClientIDMode="Static" />
                </div>
            </div>
            <h2>Other Details</h2>
            <div class="row">
                <div class="col-md-4">
                    <label for="txtHobbies">Hobbies:</label>
                    <asp:TextBox ID="txtHobbies" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="txtComments">Comments/ Feedback:</label>
                    <asp:TextBox ID="txtComments" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
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
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClientClick="return validateForm();" OnClick="btnSubmitClick" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-secondary ml-2" OnClientClick="resetForm();" />
            </div>
        </div>
    </main>

</asp:Content>
