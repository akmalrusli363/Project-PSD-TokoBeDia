<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="TokoBeDia.View.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>User Profile</h2>
    <div class="contentForm-long">
        <div>
            <asp:Label ID="EmailLabel" runat="server" Text="Email:"></asp:Label>&nbsp<br />
            <asp:TextBox ID="EmailBox" runat="server" ReadOnly="true" Width="100%"></asp:TextBox>
            <br />
        
            <asp:Label ID="UsernameLabel" runat="server" Text="Name:"></asp:Label>&nbsp<br />
            <asp:TextBox ID="UsernameBox" runat="server" ReadOnly="true" Width="100%"></asp:TextBox>
            <br />
        
            <asp:Label ID="GenderLabel" runat="server" Text="Gender:"></asp:Label><br />
            <asp:TextBox ID="GenderBox" runat="server" ReadOnly="true" Width="100%"></asp:TextBox>
            <br />
        </div>

        <br />
        <div class="form-buttons">
            <asp:Button ID="UpdateProfileButton" runat="server" Text="Update Profile" OnClick="updateProfile" />&nbsp
            <asp:Button ID="ChangePasswordButton" runat="server" Text="Change Password" OnClick="changePassword" />
        </div>
    </div>
</asp:Content>
