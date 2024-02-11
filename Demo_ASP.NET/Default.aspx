<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Demo_ASP.NET._Default" %>

<%@ Register Src="~/StudentUserControl.ascx" TagName="Student" TagPrefix="uc" %>
<%@ Register Src="~/PageNameUserControl.ascx" TagPrefix="NameUC" TagName="PageNameUserControl" %>
<%@ Register Src="~/NoteUserControl.ascx" TagPrefix="NoteUC" TagName="NoteUserControl" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%-- user control to display page name --%>
    <NameUC:PageNameUserControl runat="server" ID="PageNameUserControl" PageName="Default" />
    <main>

        <%-- Practicing user control --%>
        <uc:Student ID="studentcontrol" runat="server" />

        <%-- usercontrol for note and gridview of notes of that id and pageName --%>
        <NoteUC:NoteUserControl runat="server" ID="NoteUserControl" PageName="Default" />
    </main>

</asp:Content>
