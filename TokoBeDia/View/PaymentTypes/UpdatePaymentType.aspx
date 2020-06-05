<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="UpdatePaymentType.aspx.cs" Inherits="TokoBeDia.View.PaymentTypes.UpdatePaymentType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TokoBeDia Admin - Update Payment Types</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update Payment Types</h2>
    <div class="contentForm-short">
        <div>
            <asp:Label ID="PaymentTypeNameLabel" runat="server">Payment type name:</asp:Label><br />
            <asp:TextBox ID="PaymentTypeNameBox" runat="server" Width="100%"></asp:TextBox>
            
            <br />
        </div>
        <br />
        <div class="form-buttons">
            <div>
                <asp:Button ID="UpdatePaymentTypeButton" runat="server" Text="Update" OnClick="updatePaymentType" Width="50%" />
            </div>
            <div>
                <asp:Label ID="ErrorMessage" runat="server" CssClass="warning-text"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
