<%@ Page Title="Users List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="DemoUserManagement.Users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container">
        <h1 class="text-center">List of all Users</h1>
        <div class="mb-3">
            <asp:Button ID="btnAddUser" CssClass="btn btn-dark float-end " runat="server" Text="Add User" OnClick="btnAddUser_Click" />
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowEditing="gvUsers_RowEditing" OnRowDeleting="gvUsers_RowDeleting"
            AllowPaging="true" PageSize="5" AllowCustomPaging="true" OnPageIndexChanging="PagingGridView" AllowSorting="true" OnSorting="SortingGridView"
            DataKeyNames="UserID" CssClass="table table-striped">
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="User ID" ReadOnly="True" ItemStyle-CssClass="gridview-column" SortExpression="UserID" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" ItemStyle-CssClass="gridview-column" SortExpression="FirstName" />
                <asp:BoundField DataField="DateOfBirth" HeaderText="Date of Birth" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="gridview-column" SortExpression="DateOfBirth" />
                <asp:BoundField DataField="AadharNo" HeaderText="Aadhar No" ItemStyle-CssClass="gridview-column" SortExpression="AadharNo" />
                <asp:BoundField DataField="Email" HeaderText="Email" ItemStyle-CssClass="gridview-column" SortExpression="Email" />
                <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" ItemStyle-CssClass="gridview-column" SortExpression="PhoneNumber" />
                <asp:TemplateField HeaderText="Resume">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" Text="Download" NavigateUrl='<%# ResolveUrl("~/Upload/") + Eval("UniqueFileName") %>' Target="_blank"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" ButtonType="Button" ShowDeleteButton="True" />
            </Columns>
            <RowStyle CssClass="gridview-row" />
            <PagerStyle CssClass="gridview-paging" />
        </asp:GridView>
    </main>
</asp:Content>
