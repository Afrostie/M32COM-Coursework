<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Products.aspx.cs" Inherits="M32COM___Coursework.Products" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="breadcrumb">
        <h1>CakeHouse Cakes</h1>
    </div>
    <asp:Panel ID="pnlAdmin" runat="server" Visible="False">
        <div class="products clearfix">
            <div class="col-sm-6 col-md-3">
                <asp:Label ID="lblCakeName" runat="server" Text="Name" CssClass="label label-default"></asp:Label>
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="True" ShowSummary="False" />
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBoxCakeName" ErrorMessage="Full product name is required" ToolTip="Full product name is required" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage=" Product name must be Characters Only" ControlToValidate="txtBoxCakeName" ValidationExpression="^[a-zA-Z\s]*$" ToolTip=" Product name must be Characters Only" Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
                <asp:TextBox ID="txtBoxCakeName" runat="server" CssClass="txtbox"></asp:TextBox>
            </div>
            <div class="col-sm-6 col-md-3">
                <asp:Label ID="lblCakePrice" runat="server" Text="Price" CssClass="label label-default"></asp:Label>
                <br />
                <br />
               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBoxCakePrice" ErrorMessage="Price is required" ToolTip="Price is required" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Product price must be Numbers Only" ControlToValidate="txtBoxCakePrice" ValidationExpression="^(?!0(\.| \,)00)\d{1,3}(,\d{3})*((\.|\,)\d\d)?$" ToolTip="Product price must be Numbers Only" Text="*" ForeColor="Red"></asp:RegularExpressionValidator> 
                <asp:TextBox ID="txtBoxCakePrice" runat="server" CssClass="txtbox"></asp:TextBox>
            </div>
            <div class="col-sm-6 col-md-3">
                <asp:Label ID="lblCakeImage" runat="server" Text="Image" CssClass="label label-default"></asp:Label>
                <br />
                <br />
                <asp:FileUpload ID="ImageUpload" runat="server" CssClass="form-control" />
            </div>
            <div class="col-sm-6 col-md-3">
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
               <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Out of Range" ControlToValidate="txtBoxCakeDescription" ForeColor="Red" ToolTip="Out of Range" ValidationExpression="\w{5,900}">*</asp:RegularExpressionValidator>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Description is required" ControlToValidate="txtBoxCakeDescription" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:TextBox ID="txtBoxCakeDescription" runat="server" TextMode="MultiLine" CssClass="txtbox txtbox-custom"></asp:TextBox>
            </div>
            <div class="col-xs-12">
                <asp:Button ID="btnAddCake" runat="server" Text="Add Product" ToolTip="Add Cake" OnClick="AddCake_Click" CssClass="button" />
            </div>
        </div>
    </asp:Panel>
    <div class="products-content">
        <div class="categories">
            <div class="col-xs-12 col-centered">
                <asp:Button ID="btnBirthdayCakes" Text="Birthdays" runat="server" ToolTip="Birthday Cakes" CssClass="button" OnClick="btnBirthdayCakes_Click" CausesValidation="False" />
                <asp:Button ID="btnCelebrationCakes" Text="Celebrations" runat="server" ToolTip="Celebration Cakes" CssClass="button" OnClick="btnCelebrationCakes_Click" CausesValidation="False" />
                <asp:Button ID="btnWeddingCakes" Text="Weddings" runat="server" ToolTip="Wedding Cakes" CssClass="button" OnClick="btnWeddingCakes_Click" CausesValidation="False" />
                <asp:Button ID="btnTeaTimeCakes" Text="Teatime" runat="server" ToolTip="Teatime Cakes" CssClass="button" OnClick="btnTeaTimeCakes_Click" CausesValidation="False" />
                <asp:Button ID="btnAllCakes" Text="All" runat="server" ToolTip="All Cakes" CssClass="button" OnClick="btnAllCakes_Click" CausesValidation="False" />
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
                            <asp:Label ID="lblCakePrice" Text='<%# string.Format( Session["CurrentFormat"] + "{0:##,#.00}", Math.Round(((decimal)Eval("Price") * (decimal)Session["CurrentRate"]), 2))%>' runat="server" CssClass="price" />
                            <asp:Label ID="lblSelectQuantity" Text="Select Quantity: " runat="server" CssClass="quantity" />
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
                            <asp:Button ID="btnAddToCart" Text="Add To Cart" runat="server" CssClass="button" ToolTip="Add To Cart" OnClientClick="AddToCart" CommandName="AddToCart" CommandArgument='<%# Eval("ProductID") %>' CausesValidation="False" />
                            <asp:Button ID="btnAddToWL" Text="Add To Wish List" runat="server" Visible="false" />
                            <asp:Button ID="btnRemoveItem" Text="Remove Product" runat="server" CssClass="button" ToolTip="Remove Item" Visible="false" CommandName="RemoveCake" CommandArgument='<%# Eval("ProductID") %>' CausesValidation="False"/>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
