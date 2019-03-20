<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="Pages.PagesShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="ShoppingCart" runat="server"></asp:Panel>
    
    <table>
        <tr>
            <td><b>Total:</b></td>
            <td><asp:Literal ID="Total" runat="server" Text=""></asp:Literal></td>
        </tr>
        
        <tr>
            <td><b>Vat:</b></td>
            <td><asp:Literal ID="Vat" runat="server" Text=""></asp:Literal></td>
        </tr>
        
        <tr>
            <td><b>Shipping:</b></td>
            <td>15</td>
        </tr>
        
        <tr>
            <td><b>Total amount:</b></td>
            <td><asp:Literal ID="TotalAmount" runat="server" Text=""></asp:Literal></td>
        </tr>
        
        <tr>
            <td>
                <asp:LinkButton ID ="Continue" runat="server" PostBackUrl="~/Index.aspx">Continue shopping</asp:LinkButton>
             <asp:Button runat="server" Text="Checkout" ID="Checkout" PostBackUrl="~/Pages/Success.aspx"
                         CssClass="button" Width="250px"/>
                </td>
        </tr>
    </table>
    </asp:Content>

