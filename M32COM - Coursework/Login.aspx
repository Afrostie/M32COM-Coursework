<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="M32COM___Coursework.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CakeHouse Login Page</title>
    <style type="text/css">
        .auto-style2 {
            width: 30%;
            border-style: solid;
            border-width: 2px;
        }

        .TBStyle {
            float: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="font-family: Calibri;">Welcome to CakeHouse!</h1>
            <asp:Panel ID="LoginPanel" runat="server" HorizontalAlign="Center">
                <table class="auto-style2">
                    <tr>
                        <td>
                            <asp:Label ID="UserLabel" runat="server" Text="UserName: "></asp:Label></td>
                        <td class="TBStyle">
                            <asp:TextBox ID="UserNameTB" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="PasswordLabel" runat="server" Text="Password: "></asp:Label></td>
                        <td class="TBStyle">
                            <asp:TextBox ID="PasswordTB" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="Button1_Click" Style="height: 26px" /></td>
                    </tr>
                                        <tr>
                        <td colspan="2">
                            <asp:Button ID="RegisterButton" runat="server" Text="Register"  Style="height: 26px" OnClick="RegisterButton_Click" /></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div>
            <asp:Panel ID="RegisterPanel" runat="server" Visible="False" HorizontalAlign="Center">

                <table class="auto-style2">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="UserName: "></asp:Label></td>
                        <td class="TBStyle">
                            <asp:TextBox ID="UserRegister" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label></td>
                        <td class="TBStyle">
                            <asp:TextBox ID="PasswordRegister" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Email: "></asp:Label></td>
                        <td class="TBStyle">
                            <asp:TextBox ID="EmailRegister" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Name: "></asp:Label></td>
                        <td class="TBStyle">
                            <asp:TextBox ID="NameRegister" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Address: "></asp:Label></td>
                        <td class="TBStyle">
                            <asp:TextBox ID="AddressRegister" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="Register" runat="server" Text="Register" OnClick="Register_Click" Style="height: 26px" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="ShowLogin" runat="server" Text="Login" OnClick="ShowLogin_Click" /></td>
                    </tr>
                </table>

            </asp:Panel>
        </div>
    </form>
</body>
</html>
