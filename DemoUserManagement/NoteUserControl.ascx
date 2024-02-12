<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NoteUserControl.ascx.cs" Inherits="DemoUserManagement.NoteUserControl" %>
<style>
       .row {
       margin-bottom: 20px;
   }

   label {
       font-weight: bold;
       color: #0056b3;
   }
   textarea{
        
     border: 1px solid #007bff;
     border-radius: 3px;
     padding: 6px 10px;
 }
   
</style>
 <label for="noteTextBox">Add a Note:</label>
<asp:TextBox ID="noteTextBox" runat="server"></asp:TextBox>
<asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
    AllowSorting="true" OnSorting="SortingGridView"
    AllowPaging="True" AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="PagingGridView">

    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
        <asp:BoundField DataField="ObjectID" HeaderText="Object ID" SortExpression="ObjectID"/>
        <asp:BoundField DataField="ObjectType" HeaderText="Object Type" SortExpression="ObjectType" />
        <asp:BoundField DataField="Note" HeaderText="Note" SortExpression="Note"/>
        <asp:BoundField DataField="DateTime" HeaderText="Date Time" SortExpression="DateTime"/>
    </Columns>
</asp:GridView>
