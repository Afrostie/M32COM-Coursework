<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="M32COM___Coursework.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div class="login">
        <asp:TextBox ID="UserNameTB" runat="server">Username</asp:TextBox>
        <br/>
        <asp:TextBox ID="PasswordTB" runat="server">Password</asp:TextBox>
        <br/>
        <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" class="button" />
    </div>
    <div class="registration">
        <asp:TextBox ID="TextBox1" runat="server"> Username</asp:TextBox>
        <br/>
        <asp:TextBox ID="TextBox2" runat="server">Password</asp:TextBox>
        <br/>
        <asp:TextBox ID="TextBox3" runat="server">Email</asp:TextBox>
        <br/>
        <asp:TextBox ID="TextBox4" runat="server">Name</asp:TextBox>
        <br/>
        <asp:TextBox ID="TextBox5" runat="server">Address</asp:TextBox>
        <br/>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>User</asp:ListItem>
            <asp:ListItem>Admin</asp:ListItem>
        </asp:DropDownList>
        <br/>
        <asp:Button ID="Register" runat="server" Text="Register" OnClick="Register_Click" style="height: 26px"/>
    </div>
</form>
</body>
</html>