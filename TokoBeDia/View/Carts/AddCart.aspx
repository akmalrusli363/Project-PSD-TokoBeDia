<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="AddCart.aspx.cs" Inherits="TokoBeDia.View.Carts.AddCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="ProductNameLabel" runat="server" Font-Bold="True">Name:</asp:Label><br />
        <asp:Label ID="ProductNameBox" runat="server" Width="100%" ReadOnly="true" Font-Italic="True"></asp:Label>
        <br /><br />
        <asp:Label ID="PriceLabel" runat="server" Font-Bold="True">Price:</asp:Label><br />
        <asp:Label ID="PriceBox" runat="server" Width="100%" TextMode="Number" ReadOnly="true" Font-Italic="True"></asp:Label>
        <br /><br />
        <asp:Label ID="StockLabel" runat="server" Font-Bold="True">Stock:</asp:Label><br />
        <asp:Label ID="StockBox" runat="server" Width="100%" TextMode="Number" ReadOnly="true" Font-Italic="True"></asp:Label>
        <br /><br />
        <asp:Label ID="ProductTypeLabel" runat="server" Font-Bold="True">Type:</asp:Label><br />
        <asp:Label ID="ProductTypeBox" runat="server" Width="100%" ReadOnly="true" Font-Italic="True"></asp:Label>
        <br /><br />
        <asp:Label ID="QtyLabel" runat="server" Font-Bold="True">Quantity: </asp:Label>
        <asp:TextBox ID="QtyBox" runat="server" Font-Italic="True"></asp:TextBox>
        <br /><br />
        <asp:Button ID="AddToCartButton" runat="server" Text="Add to Cart" OnClick="AddToCartButton_Click"/>
        <br />
        <asp:Label ID="ErrorMessage" runat="server" CssClass="warning-text"></asp:Label>
        <br />
    </div>




</asp:Content>
