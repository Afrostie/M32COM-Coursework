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
        <asp:Repeater ID="rptUserOrders" runat="server">
            <ItemTemplate>
                <div class="usersorder">
                    <div class="col-md-1">
                        <asp:Label ID="lblOrderID" Text="Order ID" runat="server" />
                        <asp:Label ID="lblID" Text="" runat="server" />
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="lblUserName" Text="User Name" runat="server" />
                        <asp:Label ID="lblUName" Text="" runat="server" />
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="lblItemName" Text="Item Name" runat="server" />
                        <asp:Label ID="lblIName" Text="" runat="server" />
                    </div>
                    <div class="col-md-1">
                        <asp:Label ID="lblItemPrice" Text="Item Price" runat="server" />
                        <asp:Label ID="lblPrice" Text="" runat="server" />
                    </div>
                    <div class="col-md-1">
                        <asp:Label ID="lblItemQuantity" Text="Item Quantity" runat="server" />
                        <asp:Label ID="lblQuantity" Text="" runat="server" />
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="lblDateOrdered" Text="Date Ordered" runat="server" />
                        <asp:Label ID="lblDate" Text="" runat="server" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
