<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="TokoBeDia.View.Products.UpdateProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TokoBeDia Admin - Update Product</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update Product</h2>
    <div class="contentForm-short">
            <div>
                <asp:Label ID="ProductNameLabel" runat="server">Name:</asp:Label><br />
                <asp:TextBox ID="ProductNameBox" runat="server" Width="100%"></asp:TextBox>
                <br />
                <asp:Label ID="PriceLabel" runat="server">Price:</asp:Label><br />
                <asp:TextBox ID="PriceBox" runat="server" Width="100%" TextMode="Number"></asp:TextBox>
                <br />
                <asp:Label ID="StockLabel" runat="server">Stock:</asp:Label><br />
                <asp:TextBox ID="StockBox" runat="server" Width="100%" TextMode="Number"></asp:TextBox>
                <br />
            </div>
            <br />
            <div class="form-buttons">
                <div>
                    <asp:Button ID="UpdateProductButton" runat="server" Text="Update" OnClick="updateProduct" Width="50%"/>
                </div>
                <div>
                    <asp:Label ID="ErrorMessage" runat="server" CssClass="warning-text"></asp:Label>
                </div>
            </div>
        </div>
</asp:Content>
