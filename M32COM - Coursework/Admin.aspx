<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Admin.aspx.cs" Inherits="M32COM___Coursework.Admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="breadcrumb">
        <h1>Users Order List</h1>
    </div>
    <div class="usersorder-list">
        <div class="col-xs-12">
            <asp:Label ID="lblSelectUser" Text="Select User: " runat="server" CssClass="label label-default" />
            <asp:DropDownList ID="ddUserList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddUserList_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </div>
</asp:Content>
