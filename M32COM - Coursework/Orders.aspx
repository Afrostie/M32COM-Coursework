<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Orders.aspx.cs" Inherits="M32COM___Coursework.Orders" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="breadcrumb">
        <h1>Orders in the Cart</h1>
    </div>
    <asp:Panel ID="pnlAdmin" runat="server" Visible="false">
        <div class="orders">
            <div class="col-md-3">
                <asp:Label ID="lblCake1" runat="server" Text="Cake 1" CssClass="label label-default"></asp:Label>
                <asp:Button ID="btnAddOrder1" runat="server" Text="Add" OnClick="AddOrder1_Click" CssClass="button" />
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lblCake2" runat="server" Text="Cake 2" CssClass="label label-default"></asp:Label>
                <asp:Button ID="btnAddOrder2" runat="server" Text="Add" OnClick="AddOrder2_Click" CssClass="button" />
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="dropdown">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lblCake3" runat="server" Text="Cake 3" CssClass="label label-default"></asp:Label>
                <asp:Button ID="btnAddOrder3" runat="server" Text="Add" OnClick="AddOrder3_Click" CssClass="button" />
                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="dropdown">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>

                </asp:DropDownList>0
            </div>
            <div class="col-md-3">
                <asp:Label ID="lblCartTotal" runat="server" Text="Cart Total: " CssClass="label label-default"></asp:Label>
                <asp:Label ID="lblTotal" runat="server" Text="" CssClass="label label-default"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btnOrderCart" runat="server" Text="Order Cart" ToolTip="Order Cart" OnClick="OrderCart_Click" CssClass="button" />
                <asp:Button ID="btnClearCart" runat="server" Text="Clear Cart" ToolTip="Clear Cart" OnClick="ClearCart_Click" CssClass="button" />
            </div>
            <div class="col-xs-12">
                <asp:Panel ID="Panel1" runat="server" Visible="False">
                    <asp:Label ID="lblCurrentItems" runat="server" Text="Current Cart Items: " CssClass="label label-default"></asp:Label>
                    <br />
                    <asp:Label ID="Cart0" runat="server" Text="Cart 1: " CssClass="label label-default"></asp:Label>
                    <br />
                    <asp:Label ID="Cart1" runat="server" Text="Cart 2: " CssClass="label label-default"></asp:Label>
                    <br />
                    <asp:Label ID="Cart2" runat="server" Text="Cart 3: " CssClass="label label-default"></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </asp:Panel>
    <div class="orders-content">
        <asp:Repeater ID="rptCartItem" runat="server">
            <ItemTemplate>
                <div class="ordered-cake">
                    <div class="col-md-2">
                        <asp:Image ID="CakeImage" ImageUrl='<%# Eval("Image")%>' runat="server" />
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="lblCakeName" Text='<%# Eval("Name")%>' runat="server" CssClass="title" />
                    </div>
                    <div class="col-md-2">
                        <span class="price-label">Price: </span>
                        <asp:Label ID="lblCakePrice" Text='<%# (string) Session["CurrentFormat"] + Math.Round(((decimal) Eval("Price") * (decimal) Session["CurrentRate"]),2)%>' runat="server" CssClass="price" />
                    </div>
                    <div class="col-md-2">
                        <span class="quantity-label">Quantity: </span>
                        <asp:Label ID="lblCakeQuantities" Text='<%# Eval("value")%>' runat="server" CssClass="quantity" />
                    </div>
                    <div class="col-md-3 text-center">
                        <asp:Button ID="btnRemoveCake" Text="Remove Cake" runat="server" ToolTip="Remove Cake" CssClass="button" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="totalprice">
            <div class="col-md-9">
                <asp:Label ID="lblTotalTitle" Text="Total: " runat="server" />
                <asp:Label ID="lblTotalPrice" Text="" runat="server" />
            </div>
            <div class="col-md-3 text-center">
                <asp:Button ID="btnOrderCakes" Text="Order Cakes" runat="server" ToolTip="Order Cakes" CssClass="button" OnClick="btnOrderCakes_Click" />
            </div>
        </div>
    </div>
</asp:Content>
