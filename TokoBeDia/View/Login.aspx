<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TokoBeDia.View.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TokoBeDia - Login</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Login to TokoBeDia</h2>
    <div class="contentForm-short">
        <div>
            <asp:Label ID="EmailLabel" runat="server" Text="Email:"></asp:Label>&nbsp<br />
            <asp:TextBox ID="EmailBox" runat="server" Width="100%"></asp:TextBox>
            <br />

            <asp:Label ID="PasswordLabel" runat="server" Text="Password:"></asp:Label>&nbsp<br />
            <asp:TextBox ID="PasswordBox" runat="server" TextMode="Password" Width="100%"></asp:TextBox>
            <br />

            <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me" Width="100%" />
        </div>
        <br />

        <div class="form-buttons">
            <asp:Button ID="LoginButton" runat="server" Text="Login" Width="60%" OnClick="performLogin" /><br />
            <asp:Label ID="ErrorMessage" runat="server" Text="" CssClass="warning-text"></asp:Label>
        </div>
    </div>
</asp:Content>
