<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Demo_ASP.NET._Default" %>
<%@ Register Src="~/StudentUserControl.ascx" TagName="Student" TagPrefix="uc" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">ASP.NET</h1>
            <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
          
        </section>

       

         <uc:Student ID="studentcontrol" runat="server" />
    </main>

</asp:Content>
