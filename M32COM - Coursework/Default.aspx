<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="M32COM___Coursework.Default" %>

<%--<%@ Register Src="~/Widgets/SlideShow.ascx" TagName="SlideShow" TagPrefix="module" %>--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- <div class="jumbotron">
        <%--<module:SlideShow ID="SlideShowModule" runat="server" />--%>
    </div>
    <div class="entry-content">
        <asp:Repeater ID="rptMainContent" runat="server">
            <ItemTemplate>
                <asp:Label ID="lblTitle" Text='<%# Eval("PostTitle") %>' runat="server" />
                <asp:Literal ID="literalContent" Text='<%# Eval("PostContent") %>' runat="server" />
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div></div>-->

    <asp:Panel ID="pnlRegister" runat="server">
        <div class="register">
            <asp:TextBox ID="TextBox1" runat="server">Username</asp:TextBox>
            <br />
            <asp:TextBox ID="TextBox2" runat="server">Password</asp:TextBox>
            <br />
            <asp:TextBox ID="TextBox3" runat="server">Email</asp:TextBox>
            <br />
            <asp:TextBox ID="TextBox4" runat="server">Name</asp:TextBox>
            <br />
            <asp:TextBox ID="TextBox5" runat="server">Address</asp:TextBox>
            <br />
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="Register_Click" Style="height: 26px" />
        </div>
    </asp:Panel>
</asp:Content>
