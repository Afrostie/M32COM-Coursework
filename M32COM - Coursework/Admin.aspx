<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Admin.aspx.cs" Inherits="M32COM___Coursework.Admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="breadcrumb">
        <h1>Admin</h1>
    </div>
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" CssClass="button" />
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
</asp:Content>
