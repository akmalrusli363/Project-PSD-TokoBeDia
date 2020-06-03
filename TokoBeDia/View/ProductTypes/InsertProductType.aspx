<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="InsertProductType.aspx.cs" Inherits="TokoBeDia.View.ProductTypes.InsertProductType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TokoBeDia Admin - Insert Product Type</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Insert Product Type</h2>
    <div class="contentForm-short">
        <div>
            <asp:Label ID="ProductTypeNameLabel" runat="server">Product type name:</asp:Label><br />
            <asp:TextBox ID="ProductTypeNameBox" runat="server" Width="100%"></asp:TextBox>
            <br />
            <asp:Label ID="DescriptionLabel" runat="server">Description:</asp:Label><br />
            <asp:TextBox ID="DescriptionBox" runat="server" Height="80px" Width="100%" TextMode="MultiLine"></asp:TextBox>
            <br />
        </div>
        <br />
        <div class="form-buttons">
            <div>
                <asp:Button ID="InsertProductTypeButton" runat="server" Text="Insert" OnClick="insertProductType" Width="50%" />
            </div>
            <div>
                <asp:Label ID="ErrorMessage" runat="server" CssClass="warning-text"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
