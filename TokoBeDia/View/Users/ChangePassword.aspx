<%@ Page Title="TokoBeDia - Change Password" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="TokoBeDia.View.Profiles.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>User Profile</h2>
    <div class="contentForm-long">
        <div>
            <asp:Label ID="OldPasswordLabel" runat="server" Text="Old Password:"></asp:Label>&nbsp<br />
            <asp:TextBox ID="OldPasswordBox" runat="server" TextMode="Password" Width="100%"></asp:TextBox>
            <br />

            <asp:Label ID="NewPasswordLabel" runat="server" Text="New Password:"></asp:Label>&nbsp<br />
            <asp:TextBox ID="NewPasswordBox" runat="server" TextMode="Password" Width="100%"></asp:TextBox>
            <br />

            <asp:Label ID="ConfirmPasswordLabel" runat="server" Text="Confirm New Password:"></asp:Label>&nbsp<br />
            <asp:TextBox ID="ConfirmPasswordBox" runat="server" TextMode="Password" Width="100%"></asp:TextBox>
            <br />
        </div>

        <br />
        <div class="form-buttons">
            <div>
                <asp:Button ID="ChangePasswordButton" runat="server" Text="Change Password" OnClick="changePassword" />
            </div>
            <div>
                <asp:Label ID="ErrorMessage" runat="server" CssClass="warning-text"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
