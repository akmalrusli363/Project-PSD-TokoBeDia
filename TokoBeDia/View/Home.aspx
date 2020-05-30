<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TokoBeDia.View.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <% if (Session["user"] == null)
        { %>
    <h2>Welcome to TokoBeDia!</h2>
    <p>Login or register to TokoBeDia to purchase every local-made product just for you!</p>
    <% } %>
    <% else
        { %>
    <h2>Welcome,
        <asp:Literal ID="usernameLabel" runat="server">user</asp:Literal>!</h2>
    <% } %>


    <% if (Session["user"] != null &&
                TokoBeDia.Repository.UserRepository.isAdmin(Int32.Parse(Session["user"].ToString())))
        { %>
    <p>TokoBeDia Admin Menu:</p>
    <ul>
        <li><a href="/View/Users/ManageUsers.aspx">Manage Users</a></li>
        <li><a href="/View/Products/InsertProduct.aspx">Insert Products</a></li>
        <li><a href="/View/Products/ViewProduct.aspx">Manage Products</a></li>
        <li><a href="/View/ProductTypes/InsertProductType.aspx">Insert Product Types</a></li>
        <li><a href="/View/ProductTypes/ViewProductType.aspx">Manage Product Types</a></li>
    </ul>
    <% } %>
    <% else
        { %>
    <p>Featured Products:</p>
    <asp:BulletedList ID="listProducts" runat="server">
    </asp:BulletedList>
    <% } %>

</asp:Content>
