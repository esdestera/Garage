<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageProductTypes.aspx.cs" Inherits="Pages_Management_ManageProductTypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        Name</p>
    <p>
        <asp:TextBox ID="Name" runat="server" Width="126px"></asp:TextBox>
    </p>
    <p>
        Image</p>
        <asp:DropDownList ID="ImageDropdown" runat="server">
        </asp:DropDownList>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="SubmitButton" runat="server" OnClick="SubmitButton_Click" Text="Submit" Width="64px" />
    </p>
    <p>
        <asp:Label ID="LabelResults" runat="server" Text="Label"></asp:Label>
    </p>
</asp:Content>

