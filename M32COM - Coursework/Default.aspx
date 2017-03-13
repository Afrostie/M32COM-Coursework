<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="M32COM___Coursework.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Page!</title>
</head>
<body>
    <form id="form1" runat="server">  
        <div>
            <h1>M32COM Group Coursework Test Page!!</h1>
            <br/>
            <asp:Button ID="Button1" runat="server" Text="Log Out" OnClick="Button1_Click" />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label">Current Cart: </asp:Label>
            <asp:Label ID="CartLabel" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="Button2" runat="server" Text="Add 1 to Cart" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
