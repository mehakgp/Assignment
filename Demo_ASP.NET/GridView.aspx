<%@ Page Title="GridView" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="Demo_ASP.NET.GridView" %>

<%@ Register Src="~/PageNameUserControl.ascx" TagPrefix="NameUC" TagName="PageNameUserControl" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <NameUC:PageNameUserControl runat="server" ID="PageNameUserControl" PageName="GridView" />
        <div>
            <h3>STUDENT TABLE</h3>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                AllowSorting="true" OnSorting="SortingGridView"
                AllowPaging="True" AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="PagingGridView"
                CssClass="gridview">

                <Columns>

                    <asp:BoundField DataField="StudentID" HeaderText="ID" SortExpression="StudentID" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />

                </Columns>


            </asp:GridView>

            <asp:Button ID="btnAdd" runat="server" Text="Add New Student" OnClick="btnAdd_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update Student" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete Student" OnClick="btnDelete_Click" />

            <asp:Panel ID="pnlAddStudent" runat="server" Visible="false">
                <h4>Add New Student</h4>
                <asp:TextBox ID="txtAddFirstName" runat="server" placeholder="Enter First Name"></asp:TextBox>
                <asp:TextBox ID="txtAddLastName" runat="server" placeholder="Enter Last Name"></asp:TextBox>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </asp:Panel>
            <asp:Panel ID="pnlUpdateStudent" runat="server" Visible="false">
                <h4>Update Student</h4>
                <asp:TextBox ID="txtUpdateStudentID" runat="server" placeholder="Enter Student ID"></asp:TextBox>
                <asp:TextBox ID="txtUpdateFirstName" runat="server" placeholder="Enter First Name"></asp:TextBox>
                <asp:TextBox ID="txtUpdateLastName" runat="server" placeholder="Enter Last Name"></asp:TextBox>
                <asp:Button ID="btnUpdateSave" runat="server" Text="Save" OnClick="btnUpdateSave_Click" />
            </asp:Panel>

            <asp:Panel ID="pnlDeleteStudent" runat="server" Visible="false">
                <h4>Delete Student</h4>
                <asp:TextBox ID="txtDeleteStudentID" runat="server" placeholder="Enter Student ID"></asp:TextBox>
                <asp:Button ID="btnDeleteConfirm" runat="server" Text="Delete" OnClick="btnDeleteConfirm_Click" />
            </asp:Panel>


        </div>
    </main>
</asp:Content>
