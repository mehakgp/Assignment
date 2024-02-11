<%@ Page Title="Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="DemoUserManagement.Users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
           <asp:Button ID="btnAddUser" runat="server" Text="Add User" OnClick="btnAddUser_Click" />
    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" OnRowEditing="gvUsers_RowEditing" OnRowDeleting="gvUsers_RowDeleting">
        <Columns>
            <asp:BoundField DataField="UserID" HeaderText="User ID" ReadOnly="True" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" />
            <asp:BoundField DataField="DateOfBirth" HeaderText="Date of Birth" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="AadharNo" HeaderText="Aadhar No" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
            <asp:CommandField ShowEditButton="True" ButtonType="Button" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView> 
    </main>
</asp:Content>
