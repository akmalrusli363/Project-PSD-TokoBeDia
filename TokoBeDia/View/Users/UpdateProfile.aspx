<%@ Page Title="TokoBeDia - Update Profile" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="TokoBeDia.View.Profiles.UpdateProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>User Profile</h2>
    <div class="contentForm-long">
        <div>
            <asp:Label ID="EmailLabel" runat="server" Text="Email:"></asp:Label>&nbsp<br />
            <asp:TextBox ID="EmailBox" runat="server" Width="100%"></asp:TextBox>
            <br />

            <asp:Label ID="UsernameLabel" runat="server" Text="Name:"></asp:Label>&nbsp<br />
            <asp:TextBox ID="UsernameBox" runat="server" Width="100%"></asp:TextBox>
            <br />

            <asp:Label ID="GenderLabel" runat="server" Text="Gender:"></asp:Label><br />
            <asp:RadioButtonList ID="GenderButtons" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <br />
        <div class="form-buttons">
            <div>
                <asp:Button ID="UpdateProfileButton" runat="server" Text="Update Profile" OnClick="updateProfile" />
            </div>
            <div>
                <asp:Label ID="ErrorMessage" runat="server" CssClass="warning-text"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
