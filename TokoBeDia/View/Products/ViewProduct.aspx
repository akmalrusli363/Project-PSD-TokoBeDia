<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="TokoBeDia.View.Products.ViewProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TokoBeDia - Featured Products</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>View Product</h2>
    <div>
        <asp:GridView ID="ProductTable" runat="server">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="linkSelect" runat="server" Text="Select" CommandArgument='<%#Eval("ID") %>' OnClick="linkSelect_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <br />
        <div class="contentForm-short">
            <div>
                <asp:Label ID="ProductNameLabel" runat="server">Name:</asp:Label><br />
                <asp:TextBox ID="ProductNameBox" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
                <br />
                <asp:Label ID="PriceLabel" runat="server">Price:</asp:Label><br />
                <asp:TextBox ID="PriceBox" runat="server" Width="100%" TextMode="Number" ReadOnly="true"></asp:TextBox>
                <br />
                <asp:Label ID="StockLabel" runat="server">Stock:</asp:Label><br />
                <asp:TextBox ID="StockBox" runat="server" Width="100%" TextMode="Number" ReadOnly="true"></asp:TextBox>
                <br />
                <asp:Label ID="ProductTypeLabel" runat="server">Type:</asp:Label><br />
                <asp:TextBox ID="ProductTypeBox" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
                <br />
            </div>

            <%if (Session["user"] != null &&
                                        TokoBeDia.Repository.UserRepository.isAdmin(Int32.Parse(Session["user"].ToString())))
                { %>
            <br />
            <div class="form-buttons">
                <asp:Button ID="InsertProductButton" runat="server" Text="Insert" OnClick="insertProduct" />&nbsp
                <asp:Button ID="UpdateProductButton" runat="server" Text="Update" OnClick="updateProduct" Enabled="False" />&nbsp
                <asp:Button ID="DeleteProductButton" runat="server" Text="Delete" OnClick="deleteProduct" Enabled="False" />
            </div>
            <% } %>
        </div>
    </div>
</asp:Content>
