<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NoteUserControl.ascx.cs" Inherits="Demo_ASP.NET.NoteUserControl" %>
<asp:Label ID="noteLabel" runat="server"></asp:Label>
<asp:TextBox ID="noteTextBox" runat="server"></asp:TextBox>
<asp:Button ID="Button1" runat="server" Text="submit" OnClick="Button1_Click" />

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
    AllowSorting="true" OnSorting="SortingGridView"
    AllowPaging="True" AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="PagingGridView">

    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
        <asp:BoundField DataField="ObjectID" HeaderText="Object ID" SortExpression="ObjectID"/>
        <asp:BoundField DataField="ObjectName" HeaderText="Object Name" SortExpression="ObjectName" />
        <asp:BoundField DataField="Note" HeaderText="Note" SortExpression="Note"/>
        <asp:BoundField DataField="DateTime" HeaderText="Date Time" SortExpression="DateTime"/>
    </Columns>
</asp:GridView>
