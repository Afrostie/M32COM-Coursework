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
                <asp:Label ID="lblCakeImage" runat="server" Text="Image" CssClass="label label-default"></asp:Label>
                <br />
                <br />
                <asp:TextBox ID="txtBoxCakeImage" runat="server" CssClass="txtbox"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lblCakeStock" runat="server" Text="Stock" CssClass="label label-default"></asp:Label>
                <br />
                <br />
                <asp:TextBox ID="txtBoxCakeStock" runat="server" CssClass="txtbox"></asp:TextBox>
            </div>
            <div class="col-md-12">
                <asp:Label ID="lblCakeDescription" runat="server" Text="Description" CssClass="label label-default"></asp:Label>
                <br />
                <br />
                <asp:TextBox ID="txtBoxCakeDescription" runat="server" CssClass="txtbox"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnAddCake" runat="server" Text="Add Product" ToolTip="Add Cake" OnClick="AddCake_Click" CssClass="button" />
            </div>
        </div>
    </asp:Panel>
    <div class="products-content">
        <asp:Repeater ID="rptSingleCake" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="products-cake">
                    <div class="col-md-3">
                        <asp:Image ID="CakeImage" ImageUrl='<%# Eval("Image")%>' runat="server" />
                        <asp:Label ID="lblCakeName" Text='<%# Eval("Name")%>' runat="server" CssClass="title" />
                    </div>
                    <div class="col-md-9">
                        <div class="col-md-2">
                            <span class="price">Price: 
                            <asp:Label ID="lblCakePrice" Text='<%# Eval("Price")%>' runat="server" CssClass="price" /></span>
                            <span class="stock">In Stock: 
                            <asp:Label ID="lblCakeStock" Text='<%# Eval("Stock")%>' runat="server" CssClass="stock" /></span>
                        </div>
                        <div class="col-md-10">
                            <asp:Literal ID="litCakeDescription" Text='<%# Eval("Description")%>' runat="server" />
                        </div>
                        <div class="col-md-12 text-right">
                            <asp:Button ID="btnMoreInfo" Text="More Info" runat="server" Visible="false" />
                            <asp:Button ID="btnAddToCart" Text="Add To Cart" runat="server" OnClientClick="AddToCart" />
                            <asp:Button ID="btnAddToWL" Text="Add To Wish List" runat="server" Visible="false" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
