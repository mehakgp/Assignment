<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NoteUserControl.ascx.cs" Inherits="DemoUserManagement.NoteUserControl" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <label class="form-label" for="noteTextBox">Add a Note:</label>
        <div class="input-group mb-3">
            <asp:TextBox ID="noteTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Add" OnClick="Button1_Click" />
        </div>

        <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered"
            AutoGenerateColumns="False" AllowSorting="true" OnSorting="SortingGridView"
            AllowPaging="True" AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="PagingGridView">

            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="ObjectID" HeaderText="Object ID" SortExpression="ObjectID" />
                <asp:BoundField DataField="ObjectType" HeaderText="Object Type" SortExpression="ObjectType" />
                <asp:BoundField DataField="Note" HeaderText="Note" SortExpression="Note" />
                <asp:BoundField DataField="DateTime" HeaderText="Date Time" SortExpression="DateTime" DataFormatString="{0:MM/dd/yyyy hh:mm:ss tt}" />
            </Columns>
        </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>
