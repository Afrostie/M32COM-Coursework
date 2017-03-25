<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Products.aspx.cs" Inherits="M32COM___Coursework.Products" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="breadcrumb">
        <h1>CakeHouse Cakes</h1>
    </div>
    <asp:Panel ID="pnlAdmin" runat="server" Visible="False">
            <div class="products clearfix">
        <div class="col-md-3">
            <asp:Label ID="lblCakeName" runat="server" Text="Name" CssClass="label label-default"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtBoxCakeName" runat="server" CssClass="txtbox"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:Label ID="lblCakePrice" runat="server" Text="Price" CssClass="label label-default"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtBoxCakePrice" runat="server" CssClass="txtbox"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:Label ID="lblCakeStock" runat="server" Text="Stock" CssClass="label label-default"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtBoxCakeStock" runat="server" CssClass="txtbox"></asp:TextBox>
        </div>
        <div class="col-md-3 text-center">
            <asp:Button ID="btnAddCake" runat="server" Text="Add Product" ToolTip="Add Cake" OnClick="AddCake_Click" CssClass="button" />
        </div>
        <div class="col-md-12">
            <asp:Label ID="lblCakeDescription" runat="server" Text="Description" CssClass="label label-default"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtBoxCakeDescription" runat="server" CssClass="txtbox"></asp:TextBox>
        </div>
    </div>
    </asp:Panel>

    <div class="products-content">

    </div>
</asp:Content>
