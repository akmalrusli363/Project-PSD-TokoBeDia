<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TokoBeDia.View.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TokoBeDia - Register</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Register to TokoBeDia</h2>
    <div>
        <div class="contentForm-short">
            <asp:Label ID="EmailLabel" runat="server" Text="Email:"></asp:Label>&nbsp<br />
            <asp:TextBox ID="EmailBox" runat="server" Width="100%"></asp:TextBox>
            <br />

            <asp:Label ID="UsernameLabel" runat="server" Text="Name:"></asp:Label>&nbsp<br />
            <asp:TextBox ID="UsernameBox" runat="server" Width="100%"></asp:TextBox>
            <br />

            <asp:Label ID="PasswordLabel" runat="server" Text="Password:"></asp:Label>&nbsp<br />
            <asp:TextBox ID="PasswordBox" runat="server" TextMode="Password" Width="100%"></asp:TextBox>
            <br />

            <asp:Label ID="ConfirmPasswordLabel" runat="server" Text="Confirm Password:"></asp:Label>&nbsp<br />
            <asp:TextBox ID="ConfirmPasswordBox" runat="server" TextMode="Password" Width="100%"></asp:TextBox>
            <br />

            <asp:Label ID="GenderLabel" runat="server" Text="Gender:"></asp:Label><br />
            <asp:RadioButtonList ID="GenderButtons" runat="server" Width="100%">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <br />

        Dengan mengklik Register, anda telah memahami setiap syarat dan ketentuan berlaku di TokoBeDia.
        <br />
        <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="doRegistration" />&nbsp
        <asp:Label ID="ErrorMessage" runat="server" CssClass="warning-text" Text=""></asp:Label>
    </div>
</asp:Content>
