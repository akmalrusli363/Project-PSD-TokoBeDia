<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="ViewPaymentType.aspx.cs" Inherits="TokoBeDia.View.PaymentTypes.ViewPaymentType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TokoBeDia Admin - List Payment Types</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>View Payment Types</h2>
    <div>
        <asp:GridView ID="PaymentTypeTable" runat="server">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="linkSelect" runat="server" Text="Select" CommandArgument='<%#Eval("PaymentTypeID") %>' OnClick="linkSelect_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <br />
        <div class="contentForm-short">
            <div>
                <asp:Label ID="PaymentTypeLabel" runat="server">Payment type name:</asp:Label><br />
                <asp:TextBox ID="PaymentTypeBox" runat="server" Width="100%" ReadOnly="True"></asp:TextBox>
                
                <br />
            </div>
            <br />
            <div class="form-buttons">
                <asp:Button ID="InsertPaymentTypeButton" runat="server" Text="Insert" OnClick="insertPaymentType" />&nbsp
                <asp:Button ID="UpdatePaymentTypeButton" runat="server" Text="Update" OnClick="updatePaymentType" Enabled="False" />&nbsp
                <asp:Button ID="DeletePaymentTypeButton" runat="server" Text="Delete" OnClick="deletePaymentType" Enabled="False" />
            </div>
        </div>
    </div>


</asp:Content>