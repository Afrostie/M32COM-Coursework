<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="M32COM___Coursework.Default" %>

<%--<%@ Register Src="~/Widgets/SlideShow.ascx" TagName="SlideShow" TagPrefix="module" %>--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <%--<module:SlideShow ID="SlideShowModule" runat="server" />--%>
    </div>
    <div class="entry-content">
        <h1>Welcome</h1>
        <p>content content content</p>
    </div>
    <asp:Panel ID="pnlRegister" runat="server">
        <div class="register">
            <div class="row">
                <div class="col-md-6">
                    <asp:TextBox ID="txtBoxName" runat="server" CssClass="txtbox">Your Name</asp:TextBox></div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtBoxEmail" runat="server" CssClass="txtbox">Email</asp:TextBox></div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <asp:TextBox ID="txtBoxUserName" runat="server" CssClass="txtbox">Username</asp:TextBox></div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtBoxPass" runat="server" CssClass="txtbox">Password</asp:TextBox></div>
            </div>
            
            <div class="row">
                <div class="col-xs-12">
                    <asp:TextBox ID="txtBoxAddress" runat="server" CssClass="txtbox">Address</asp:TextBox></div>
            </div>
            <div>
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="Register_Click" ToolTip="Sign Up" CssClass="button" /></div>
        </div>
    </asp:Panel>
</asp:Content>
