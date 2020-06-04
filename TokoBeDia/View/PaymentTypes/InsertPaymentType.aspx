<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="InsertPaymentType.aspx.cs" Inherits="TokoBeDia.View.PaymentTypes.InsertPaymentType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TokoBeDia Admin - Insert Payment Types</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Insert Payment Types</h2>
    <div class="contentForm-short">
        <div>
            <asp:Label ID="PaymentTypeNameLabel" runat="server">Payment type name:</asp:Label><br />
            <asp:TextBox ID="PaymentTypeNameBox" runat="server" Width="100%"></asp:TextBox>
            
            <br />
        </div>
        <br />
        <div class="form-buttons">
            <div>
                <asp:Button ID="InsertPaymentTypeButton" runat="server" Text="Insert" OnClick="insertPaymentType" Width="50%" />
            </div>
            <div>
                <asp:Label ID="ErrorMessage" runat="server" CssClass="warning-text"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
