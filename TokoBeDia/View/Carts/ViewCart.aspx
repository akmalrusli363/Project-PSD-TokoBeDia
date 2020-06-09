<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="TokoBeDia.View.Carts.ViewCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="ObjectDataSource1"  >
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" ReadOnly="True" SortExpression="Subtotal" />
                <asp:TemplateField>
                     <ItemTemplate>
                        <asp:LinkButton OnClick="lbUpdate_Click" ID="lbUpdate"  CommandArgument='<%# Eval("ProductID")%>' runat="server">Update</asp:LinkButton>
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                     <ItemTemplate>
                        <asp:LinkButton OnClick="lbDelete_Click" ID="lbDelete"  CommandArgument='<%# Eval("ProductID")%>' runat="server">Delete</asp:LinkButton>
                     </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="TokoBeDia.App_Code.ViewCartsTableAdapters.DataTable1TableAdapter">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="UserID" SessionField="user" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <div>
        <br />
        <asp:Label ID="totalLabel" runat="server" Font-Bold="True" Text="Grand Total : Rp. "></asp:Label>
        <asp:Label ID="totalLabelValue" runat="server" Font-Italic="True"></asp:Label>
    <br />
    </div>
    <div>
        <asp:Label ID="labelPayment" Visible="false" runat="server" Font-Bold="True" Font-Italic="True" Text="Select Payment Method :"></asp:Label>
        <br />
        <asp:DropDownList ID="listPaymentType" Visible="False" runat="server" DataSourceID="ObjectDataSource2" DataTextField="PaymentTypeName" DataValueField="PaymentTypeID">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="TokoBeDia.App_Code.PaymentTypeTableAdapters.PaymentTypesTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_PaymentTypeID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="PaymentTypeName" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="PaymentTypeName" Type="String" />
                <asp:Parameter Name="Original_PaymentTypeID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </div>
    <br />
    <br />
    <br />
    <asp:Button ID="CheckoutButton1" runat="server" OnClick="CheckoutButton1_Click" Text="Finish Checkout" Visible="False" />
    <br />
    <asp:Button ID="CheckoutButton2" runat="server" OnClick="CheckoutButton2_Click" Text="Checkout" />
    <br />
        <asp:Label ID="ErrorMessage" runat="server" CssClass="warning-text"></asp:Label>
        </asp:Content>
