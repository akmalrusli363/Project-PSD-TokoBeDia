<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="TokoBeDia.View.Users.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TokoBeDia Admin - Manage Users</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Manage Users</h2>
    <div>
        <asp:gridview id="UserTable" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Select User">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkSelect" runat="server" Text="Select" CommandArgument='<%#Eval("ID") %>' OnClick="selectUser" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="User ID" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="RoleID" HeaderText="RoleID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Password" HeaderText="Password" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:TemplateField HeaderText="Toggle status">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkToggleUserStatus" runat="server" Text="Toggle status" CommandArgument='<%#Eval("ID") %>' OnClick="toggleUserStatus" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Toggle admin">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkToggleAdmin" runat="server" Text="Toggle admin" CommandArgument='<%#Eval("ID") %>' OnClick="toggleUserRole" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:gridview>

        <br />
        <div class="contentForm-long">
            <div>
                <asp:label id="UsernameLabel" runat="server">Name:</asp:label><br />
                <asp:textbox id="UsernameBox" runat="server" width="100%" readonly="True" enabled="False"></asp:textbox>
                <br />
                <asp:label id="EmailLabel" runat="server">Email:</asp:label><br />
                <asp:textbox id="EmailBox" runat="server" width="100%" readonly="True" enabled="False"></asp:textbox>
                <br />
                <asp:label id="GenderLabel" runat="server">Gender:</asp:label><br />
                <asp:textbox id="GenderBox" runat="server" width="100%" readonly="True" enabled="False"></asp:textbox>
                <br />
                <asp:label id="RoleLabel" runat="server">Role:</asp:label><br />
                <asp:dropdownlist id="RoleBox" runat="server" width="100%" enabled="False">
                    <asp:ListItem>Admin</asp:ListItem>
                    <asp:ListItem>User</asp:ListItem>
                </asp:dropdownlist>
                <br />
                <asp:label id="StatusLabel" runat="server">Status:</asp:label><br />
                <asp:radiobuttonlist id="StatusButtons" runat="server" repeatdirection="Horizontal" enabled="False">
                    <asp:ListItem>Active</asp:ListItem>
                    <asp:ListItem>Blocked</asp:ListItem>
                </asp:radiobuttonlist>
            </div>
            <br />
            <div class="form-buttons">
                <div>
                    <asp:button id="UpdateUserButton" runat="server" text="Update user" onclick="updateUser" enabled="False" />
                </div>
                <div>
                    <asp:label id="ErrorMessage" runat="server" cssclass="warning-text"></asp:label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
