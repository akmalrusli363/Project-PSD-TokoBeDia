<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="TokoBeDia.View.TransactionHistory.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Transaction History</h2>
<p>
    <asp:Button ID="viewTransactionReport" runat="server" Height="34px" OnClick="toTransactionReport" Text="View Transaction Report" Width="288px" />
</p>
<p>
    <asp:GridView ID="viewTransactionHistory" runat="server">
    </asp:GridView>
</p>
</asp:Content>
