<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="DemoUserManagement.LogIn" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="Scripts/DemoUserManagement_LogIn.js"></script>
    <main>
        <div class="container">
            <h2>Login</h2>
            <div class="row">
                <div class="col-md-6">
                    <label id="lblMessage" class="text-danger" visible="false"></label>
                    <div class="form-group">
                        <label for="txtEmail">Email ID:</label>
                        <input type="text" id="txtEmail" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtPassword">Password:</label>
                        <input type="password" id="txtPassword" class="form-control" />
                    </div>
                    <div class="form-group" style="margin-top: 5px;">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClientClick="return LogIn();" />
                        <asp:HyperLink ID="lnkSignup" runat="server" NavigateUrl="~/UserDetails2.aspx" CssClass="btn btn-secondary ms-2">Signup</asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

