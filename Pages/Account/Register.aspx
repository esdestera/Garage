<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Pages_Account_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Literal ID="Status" runat="server"></asp:Literal>
    <br />
    <br />
    <asp:Label ID="UserName" runat="server" Text="User name"></asp:Label>
    <br />
    <asp:TextBox ID="UserNameTB" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Password" runat="server" Text="Password"></asp:Label>
    <br />
    <asp:TextBox ID="PasswordTB" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="ConfirmPassword" runat="server" Text="Confirm password"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="ConfirmPasswordTB" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="FirstName"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="FirstName" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Last name"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="LastName" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="Address" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Postal code"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="PostalCode" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Register" runat="server" CssClass="button" OnClick="Register_Click" Text="Register" />
</asp:Content>

