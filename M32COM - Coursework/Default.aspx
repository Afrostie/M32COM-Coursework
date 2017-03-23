<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="M32COM___Coursework.Default" %>

<%--<%@ Register Src="~/Widgets/SlideShow.ascx" TagName="SlideShow" TagPrefix="module" %>--%>

<asp:content id="BodyContent" contentplaceholderid="MainContent" runat="server">
    <div class="jumbotron">
        <%--<module:SlideShow ID="SlideShowModule" runat="server" />--%>
    </div>
    <div class="entry-content">
        <asp:Repeater ID="rptMainContent" runat="server">
            <ItemTemplate>
                <asp:Label ID="lblTitle" Text='<%# Eval("PostTitle") %>' runat="server" />
                <asp:Literal ID="literalContent" Text='<%# Eval("PostContent") %>' runat="server" />
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div></div>
</asp:content>
