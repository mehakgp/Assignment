<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="DemoUserManagement.LogIn" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container ">
            <h2>Login</h2>
            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                    <div class="form-group">
                        <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail">Email ID:</asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group" style="margin-bottom:8px;">
                        <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword">Password:</asp:Label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                        <asp:HyperLink ID="lnkSignup" runat="server" NavigateUrl="~/UserDetails.aspx" CssClass="btn btn-secondary ms-2">Signup</asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

