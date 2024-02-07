<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo_WebForm.aspx.cs" Inherits="Demo_ASP.NET.Demo_WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        td {
            width: 121px;
        }
  #submit{

      margin-top:10px;
  }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <h2>Welcome to the Web Forms!</h2>
        </div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="label1" runat="server" Text="Enter Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" BackColor="LavenderBlush" BorderColor="Crimson" ToolTip="Enter your name here"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="label2" runat="server" Text="Chose a file"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>

            </tr>
        </table>
        <div>
            <h3>Select Gender:</h3>
            <asp:RadioButton ID="RadioButton1" runat="server" Text="Male" GroupName="gender" />
            <asp:RadioButton ID="RadioButton2" runat="server" Text="Female" GroupName="gender" />
        </div>
        <div>
            <h3>Choose a date:</h3>
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </div>
        <div>
            <h3>Choose courses:</h3>
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Big Data" />
            <asp:CheckBox ID="CheckBox2" runat="server" Text="Artificial Intelligence" />
            <asp:CheckBox ID="CheckBox3" runat="server" Text="Machine Learning" />
        </div>
        <div>
            <h3>Select your city: </h3>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="">Please Select</asp:ListItem>
                <asp:ListItem>New Delhi </asp:ListItem>
                <asp:ListItem>Greater Noida</asp:ListItem>
                <asp:ListItem>NewYork</asp:ListItem>
                <asp:ListItem>Paris</asp:ListItem>
                <asp:ListItem>London</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="submit" runat="server" Text="submit" Width="120px" Height="40px" BackColor="LavenderBlush" BorderStyle="dashed" OnClick="SubmitButton" />
        </div>

        <div>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButtonClicked" >LinkButtonTest</asp:LinkButton>
        </div>
    </form>



    <div>
        <asp:Label ID="displayLinkButton" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="displayName" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="FileUploadStatus" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="displayGender" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="displayDate" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="displayCourse" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="displayCity" runat="server"></asp:Label>
    </div>
    <div>
        <asp:HyperLink ID="HyperLink1" runat="server" Text="Visit JavaTpoint" NavigateUrl="www.javatpoint.com"></asp:HyperLink>
    </div>

</body>
</html>
