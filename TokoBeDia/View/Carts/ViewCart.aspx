<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="TokoBeDia.View.Carts.ViewCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="ObjectDataSource1" >
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" ReadOnly="True" SortExpression="Subtotal" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="TokoBeDia.App_Code.ViewCartsTableAdapters.DataTable1TableAdapter">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="UserID" SessionField="user" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br /><br />
    <asp:Label ID="totalLabel" runat="server" Font-Bold="True" Text="Grand Total : Rp. "></asp:Label>
    <asp:Label ID="totalLabel1" runat="server" Font-Italic="True"></asp:Label>
</asp:Content>
