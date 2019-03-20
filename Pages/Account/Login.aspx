<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Account_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Literal ID="Status" runat="server"></asp:Literal>
    <br />
    <asp:Label ID="Label1" runat="server" Text="User name"></asp:Label>
    <br />
    <asp:TextBox ID="Username" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
    <br />
<asp:TextBox ID="Password" runat="server" CssClass="inputs"></asp:TextBox>
<br />
<br />
<asp:Button ID="Login" runat="server" CssClass="button" OnClick="Button1_Click" Text="Login" />
<br />
</asp:Content>

