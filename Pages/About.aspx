<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="Pages_About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel runat="server" style="margin-bottom: 32px">
        <asp:Label runat="server">Name:</asp:Label>
        <br />
        <asp:TextBox ID="txtName" runat="server" CssClass="input"></asp:TextBox>
        <br />
        <br />
        <asp:Label runat="server">Email:</asp:Label>
        <br />
        <asp:TextBox ID="txtEmail" runat="server" CssClass="input"></asp:TextBox>
        <br />
        <br />
        <asp:Label runat="server">Subject:</asp:Label>
        <br />
        <br />
        <asp:TextBox ID="txtSubject" runat="server" CssClass="input"></asp:TextBox>
        <br />
        <asp:Label runat="server">Message:</asp:Label>
        <br />
        <textarea runat="server" id="txtMessage" rows="7" cols="24"></textarea>
        <br />
        <asp:Button runat="server" ID="btnSend" Text="Send" CssClass="button"/>

        <asp:Button runat="server" ID="btnReset" Text="Reset" CssClass="button"/>

        <br />
        <br />

    </asp:Panel>

</asp:Content>

