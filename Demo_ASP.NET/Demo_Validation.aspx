<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo_Validation.aspx.cs" Inherits="Demo_ASP.NET.Demo_Validation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #submit {
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Enter Name: *</h3>
            <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
            <div>
                <asp:RequiredFieldValidator ID="nameValidate" runat="server" ControlToValidate="nameTextBox"
                    ForeColor="Red" ErrorMessage="Name is mandatory"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div>
            <h3>Enter Email:</h3>
            <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
            <div>
                <asp:RegularExpressionValidator ID="emailValidate" runat="server" ControlToValidate="emailTextBox"
                    ForeColor="Red" ErrorMessage="Enter valid email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
            </div>
        </div>

        <div>
            <h3>Enter Phone no:</h3>
            <asp:TextBox ID="phoneTextBox" runat="server"></asp:TextBox>
            <div>
                <asp:CustomValidator ID="phoneValidate" runat="server" ControlToValidate="phoneTextBox"
                    ForeColor="Red" ErrorMessage="It must be a 10 digit number" OnServerValidate="PhoneNoValidate"></asp:CustomValidator>
            </div>
        </div>
        
        <div>
            <h3>Select Gender:</h3>
            <asp:RadioButton ID="RadioButton1" runat="server" Text="Male" GroupName="gender" />
            <asp:RadioButton ID="RadioButton2" runat="server" Text="Female" GroupName="gender" />
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
            <asp:Button ID="submit" runat="server" Text="submit" OnClick="SubmitButton" />
        </div>
    </form>

    <div>
        <div>
            <asp:Label ID="displayName" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Label ID="displayEmail" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Label ID="displayGender" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Label ID="displayCourse" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Label ID="displayCity" runat="server"></asp:Label>
        </div>
    </div>




</body>
</html>





























