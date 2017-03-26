<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="M32COM___Coursework.Default" %>

<%--<%@ Register Src="~/Widgets/SlideShow.ascx" TagName="SlideShow" TagPrefix="module" %>--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <%--<module:SlideShow ID="SlideShowModule" runat="server" />--%>
    </div>
    <div class="entry-content text-center">
        <h1>About CakeHouse</h1>
        <p>content content content</p>
        <h2>Our Products</h2>
        <p>content content content</p>
        <p><a href="Products.aspx">Our Cakes</a></p>
    </div>
    <asp:Panel ID="pnlRegister" runat="server">
        <div class="register">
            <div class="row">
                <div class="col-md-6">
                    <asp:TextBox ID="txtBoxFullName" runat="server" CssClass="txtbox" ToolTip="Your Name" placeholder="Full Name"></asp:TextBox></div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtBoxEmail" runat="server" CssClass="txtbox" ToolTip="Email Address" placeholder="Email"></asp:TextBox></div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <asp:TextBox ID="txtBoxUserName" runat="server" CssClass="txtbox" ToolTip="UserName" placeholder="UserName"></asp:TextBox></div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtBoxPass" runat="server" CssClass="txtbox" ToolTip="Password" placeholder="Password"></asp:TextBox></div>
            </div>
            
            <div class="row">
                <div class="col-xs-12">
                    <asp:TextBox ID="txtBoxAddress" runat="server" CssClass="txtbox address" ToolTip="Delivery Address" placeholder="Address"></asp:TextBox></div>
            </div>
            <div>
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="Register_Click" ToolTip="Sign Up" CssClass="button" /></div>
        </div>
    </asp:Panel>
</asp:Content>
