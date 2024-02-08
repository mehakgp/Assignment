<%@ Page Title="GridView" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="Demo_ASP.NET.GridView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .gridview-container {
            margin-bottom: 20px;
        }

        .gridview-header {
            background-color: #007bff;
            color: #fff;
            padding: 10px;
            font-weight: bold;
        }

        .gridview-row {
            padding: 8px;
        }

            .gridview-row:nth-child(even) {
                background-color: #f2f2f2;
            }

            .gridview-row:hover {
                background-color: #cce5ff;
            }

        .gridview-action-buttons {
            white-space: nowrap;
        }

        .input-container, .button-container {
            margin-bottom: 10px;
        }
    </style>
    <main>
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
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:LinkButton ID="EditButton" runat="server" CommandName="Edit" CommandArgument='<%# Eval("StudentID") %>' Text="Edit" />
                            <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete" CommandArgument='<%# Eval("StudentID") %>' Text="Delete" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>



            <br />
            <div class="input-container">
                <label>First Name</label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </div>
            <div class="input-container">
                <label>Last Name</label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </div>
            <div class="button-container">
                <asp:Button ID="Button1" runat="server" Text="Insert" OnClick="InsertButton" />
                <asp:Button ID="Button2" runat="server" Text="Reset" OnClick="ResetButton" />
            </div>
        </div>

    </main>
</asp:Content>
