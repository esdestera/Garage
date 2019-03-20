<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="Pages.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td rowspan="4">
                <asp:Image ID="ProductImage" runat="server" CssClass="detailsImage" />
            </td>
            
            <td>
                <asp:Label ID="Name" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Description" runat="server" CssClass="detailsDescription"></asp:Label>

            </td>
            <td>
                <asp:Label ID="Price" runat="server" CssClass="detailsPrice"></asp:Label><br>
                Quantity:    
                <asp:DropDownList runat="server" Id="Amount" ></asp:DropDownList><br>
                <asp:Button ID="Add" runat="server" CssClass="button" OnClick="Add_Click" Text="Add product" /><br>
                <asp:Label runat="server" id ="Results"></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td>Product number: 
                <asp:Label ID="ItemNumber" runat="server"></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:Label ID="Available" runat="server" Text="Available"></asp:Label>
                !</td>
        </tr>
    </table>
</asp:Content>



