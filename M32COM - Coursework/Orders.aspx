<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="M32COM___Coursework.Orders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order a Product</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Cake 1"></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
            </asp:DropDownList>
            <br />

            <asp:Label ID="Label2" runat="server" Text="Cake 2"></asp:Label>
            <asp:Button ID="Button2" runat="server" Text="Add" OnClick="Button2_Click" />
            <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
            </asp:DropDownList>
            <br />

            <asp:Label ID="Label3" runat="server" Text="Cake 3"></asp:Label>
            <asp:Button ID="Button3" runat="server" Text="Add" OnClick="Button3_Click" />
            <asp:DropDownList ID="DropDownList3" runat="server">                
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>

            </asp:DropDownList>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Cart Total: "></asp:Label>
            <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
            
            <br/>
            <br/>
            <asp:Button ID="Button4" runat="server" Text="Order Cart" OnClick="Button4_Click" />
            <br />
            <asp:Button ID="Button5" runat="server" Text="Clear Cart" OnClick="Button5_Click"/>
        </div>
    </form>
</body>
</html>
