<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="M32COM___Coursework.Default" %>

<%--<%@ Register Src="~/Widgets/SlideShow.ascx" TagName="SlideShow" TagPrefix="module" %>--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div class="jumbotron">
        <module:SlideShow ID="SlideShowModule" runat="server" />
    </div>--%>
    <div class="entry-content text-center">
        <h1>About CakeHouse</h1>
        <p>content content content</p>
        <h2>Our Products</h2>
        <p>content content content</p>
        <p><a class="button" href="Products.aspx" title="See Our Cakes">Our Cakes</a></p>
        <asp:Panel ID="pnlRegister" runat="server">
            <hr />
            <h2>Register to Our Website</h2>
            <div class="register">
                <div class="col-md-6 col-centered">
                    <div class="col-xs-12">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBoxFullName" ErrorMessage="Full Name required" ToolTip="Full Name is required" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Name must be Characters Only" ControlToValidate="txtBoxFullName" ValidationExpression="^[a-zA-Z\s]*$" ToolTip="Name must be Characters Only" Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtBoxFullName" runat="server" CssClass="txtbox" ToolTip="Your Name" placeholder="Full Name"></asp:TextBox>
                    </div>
                    <div class="col-xs-12">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtBoxEmail" ErrorMessage="Not an email format" ToolTip="Not an email format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBoxEmail" ErrorMessage="Email is required" ToolTip="Email is required" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtBoxEmail" runat="server" CssClass="txtbox" ToolTip="Email Address" placeholder="Email"></asp:TextBox>
                    </div>
                    <div class="col-xs-12">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBoxUserName" ErrorMessage="Username:Please enter only alpha-numeric characters(no spaces)" ToolTip="Username:Please enter only alpha-numeric characters(no spaces)" ValidationExpression="\w{6,14}" ForeColor="Red">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBoxUserName" ErrorMessage="User name is required" ToolTip="User name is required" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtBoxUserName" runat="server" CssClass="txtbox" ToolTip="UserName" placeholder="UserName"></asp:TextBox>
                    </div>
                    <div class="col-xs-12">
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtBoxPass" ErrorMessage="Password:Please enter 6-14 characters, at least 1 uppercase letter, 1 lowercase letter, and 1 number" ToolTip="Password:Please enter 6-14 characters, at least 1 uppercase letter, 1 lowercase letter, and 1 number" ClientValidationFunction="ValidatePassword" OnServerValidate="CustomValidator1_ServerValidate" ForeColor="Red">*</asp:CustomValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBoxPass" ErrorMessage="Password is required" ToolTip="Password is required" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtBoxPass" runat="server" CssClass="txtbox" ToolTip="Password" placeholder="Password" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="col-xs-12">
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords Much Match" Text="*" ControlToCompare="txtBoxPass" ControlToValidate="txtBoxConfirmPassword" ToolTip="Passwords Much Match" ForeColor="Red"></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtBoxConfirmPassword" ErrorMessage="Confirm Password is required" ToolTip="Confirm Password is required" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtBoxConfirmPassword" runat="server" CssClass="txtbox" ToolTip="Confirm Password" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="col-xs-12">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtBoxAddress" ErrorMessage="Address is required" ToolTip="Address is required" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtBoxAddress" runat="server" CssClass="txtbox address" ToolTip="Delivery Address" placeholder="Address"></asp:TextBox>
                    </div>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="True" ShowSummary="False" />
                </div>
                <div class="col-xs-12">
                    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="Register_Click" ToolTip="Sign Up" CssClass="button" />
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
