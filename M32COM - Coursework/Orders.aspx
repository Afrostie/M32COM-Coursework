<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="M32COM___Coursework.Orders" %>
<%@ Import Namespace="M32COM___Coursework.App_Code" %>
<%@ Import Namespace="M32COM___Coursework" %>
<%@ Import Namespace="M32COM___Coursework" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order a Product</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="font-family: Calibri;">Welcome to CakeHouse!</h1>
            <asp:Panel ID="Panel1" runat="server" Visible="False">
                <asp:Label ID="Label1" runat="server" Text="Cake: "></asp:Label>
                <asp:Label ID="CakeName1" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="Label15" runat="server" Text="Description: "></asp:Label>
                <asp:Label ID="CakeDesc1" runat="server" Text=""></asp:Label>
                <br />
                <asp:DropDownList ID="Quantity1" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" Visible="False">
                <asp:Label ID="Label2" runat="server" Text="Cake: "></asp:Label>
                <asp:Label ID="CakeName2" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="Label25" runat="server" Text="Description: "></asp:Label>
                <asp:Label ID="CakeDesc2" runat="server" Text=""></asp:Label>
                <br />
                <asp:DropDownList ID="Quantity2" runat="server">
                                        <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click1" />
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server" Visible="False">
                <asp:Label ID="Label3" runat="server" Text="Cake: "></asp:Label>
                <asp:Label ID="CakeName3" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="Label35" runat="server" Text="Description: "></asp:Label>
                <asp:Label ID="CakeDesc3" runat="server" Text=""></asp:Label>
                <br />
                <asp:DropDownList ID="Quantity3" runat="server">
                                        <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click1" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
