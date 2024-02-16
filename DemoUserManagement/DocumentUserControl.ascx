<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentUserControl.ascx.cs" Inherits="DemoUserManagement.DocumentUserControl" %>
<label class="form-label" for="document">Upload your Document:</label>
<div class="input-group mb-3">
    <asp:DropDownList ID="ddlDocumentType" style="margin-right:8px" runat="server" OnSelectedIndexChanged="ddlDocumentType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    <asp:FileUpload ID="document" runat="server" CssClass="form-control" ClientIDMode="Static" />
    <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Upload" OnClick="ButtonClick" />
</div>

<asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" />
        <asp:BoundField DataField="DocumentType" HeaderText="Document Type" />
        <asp:BoundField DataField="DocumentOriginalName" HeaderText="File Name" />
        <asp:BoundField DataField="DateTime" HeaderText="Date Time" DataFormatString="{0:MM/dd/yyyy hh:mm:ss tt}" />
        <asp:TemplateField HeaderText="Download">
            <ItemTemplate>
                <asp:Button ID="btnDownload" runat="server" Text="Download" CommandName="DownloadFile" CommandArgument='<%# Eval("DocumentUniqueName") %>' />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>


