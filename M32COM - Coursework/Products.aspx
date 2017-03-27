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
                <asp:FileUpload ID="ImageUpload" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <asp:Label ID="lblCakeCateg" Text="Cake Categories" runat="server" CssClass="label label-default" />
                <br />
                <br />
                <asp:DropDownList ID="CategoryDropDown" runat="server" ToolTip="Choose Category" CssClass="form-control">
                    <asp:ListItem>Birthday-Cakes</asp:ListItem>
                    <asp:ListItem>Celebration-Cakes</asp:ListItem>
                    <asp:ListItem>Teatime-Cakes</asp:ListItem>
                    <asp:ListItem>Wedding-Cakes</asp:ListItem>
                </asp:DropDownList>
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
        <div class="categories">
            <div class="btn-birthday col-md-3">
                <asp:Button ID="btnBirthdayCakes" Text="Birthdays" runat="server" ToolTip="Birthday Cakes" CssClass="button" />
            </div>
            <div class="btn-celebration col-md-3">
                <asp:Button ID="btnCelebrationCakes" Text="Celebrations" runat="server" ToolTip="Celebration Cakes" CssClass="button" />
            </div>
            <div class="btn-wedding col-md-3">
                <asp:Button ID="btnWeddingCakes" Text="Weddings" runat="server" ToolTip="Wedding Cakes" CssClass="button" />
            </div>
            <div class="btn-teatime col-md-3">
                <asp:Button ID="btnTeaTimeCakes" Text="Teatime" runat="server" ToolTip="Teatime Cakes" CssClass="button" />
            </div>
        </div>
        <asp:Repeater ID="rptSingleCake" runat="server" OnItemCommand="rptSingleCake_ItemCommand">
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
                            <span class="price-label">Price: </span>
                            <asp:Label ID="lblCakePrice" Text='<%#(string)Session["CurrentFormat"] + Math.Round(((decimal)Eval("Price") * (decimal)Session["CurrentRate"]), 2)%>' runat="server" CssClass="price" />
                            <asp:Label ID="lblSelectQuantity" Text="Select Quantity" runat="server" />
                            <asp:DropDownList ID="ddQuantity" runat="server" CssClass="form-control">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-10">
                            <asp:Literal ID="litCakeDescription" Text='<%# Eval("Description")%>' runat="server" />
                        </div>
                        <div class="col-md-12 text-right">
                            <asp:Button ID="btnMoreInfo" Text="More Info" runat="server" Visible="false" />
                            <asp:Button ID="btnAddToCart" Text="Add To Cart" runat="server" CssClass="button" OnClientClick="AddToCart" CommandName="AddToCart" CommandArgument='<%# Eval("ProductID") %>' />
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
