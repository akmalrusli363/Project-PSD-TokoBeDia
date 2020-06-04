<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="ViewProductType.aspx.cs" Inherits="TokoBeDia.View.ProductTypes.ViewProductType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TokoBeDia Admin - List Product Types</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>View Product Types</h2>
    <div>
        <asp:GridView ID="ProductTypeTable" runat="server">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="linkSelect" runat="server" Text="Select" CommandArgument='<%#Eval("ID") %>' OnClick="linkSelect_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <br />
        <div class="contentForm-long">
            <div>
                <asp:Label ID="ProductTypeNameLabel" runat="server">Product type name:</asp:Label><br />
                <asp:TextBox ID="ProductTypeNameBox" runat="server" Width="100%" ReadOnly="True"></asp:TextBox>
                <br />
                <asp:Label ID="DescriptionLabel" runat="server">Description:</asp:Label><br />
                <asp:TextBox ID="DescriptionBox" runat="server" Height="80px" Width="100%" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                <br />
            </div>
            <br />
            <div class="form-buttons">
                <div>
                    <asp:Button ID="InsertProductTypeButton" runat="server" Text="Insert" OnClick="insertProductType" />&nbsp
                    <asp:Button ID="UpdateProductTypeButton" runat="server" Text="Update" OnClick="updateProductType" Enabled="False" />&nbsp
                    <asp:Button ID="DeleteProductTypeButton" runat="server" Text="Delete" OnClick="deleteProductType" Enabled="False" />
                </div>
                <div>
                    <asp:Label ID="ErrorMessage" runat="server" CssClass="warning-text"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
