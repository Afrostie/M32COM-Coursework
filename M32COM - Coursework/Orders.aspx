<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Orders.aspx.cs" Inherits="M32COM___Coursework.Orders" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="breadcrumb">
        <h1>Orders in the Cart</h1>
    </div>
    <div class="orders-content">
        <asp:Repeater ID="rptCartItem" runat="server" OnItemCommand="rptCartItem_ItemCommand">
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
                        <asp:Button ID="btnRemoveCake" Text="Remove Cake" runat="server" CommandName="RemoveFromCart" CommandArgument='<%# Eval("key") %>' ToolTip="Remove Cake" CssClass="button" />
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
