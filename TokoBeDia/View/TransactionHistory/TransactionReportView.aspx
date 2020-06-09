<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="TransactionReportView.aspx.cs" Inherits="TokoBeDia.View.TransactionHistory.TransactionReportView" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Transaction Report</h2>

    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />

</asp:Content>
