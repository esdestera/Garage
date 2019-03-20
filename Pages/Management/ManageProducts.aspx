<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageProducts.aspx.cs" Inherits="Pages_Management_ManageProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        Name</p>
    <p>
        <asp:TextBox ID="Name" runat="server"></asp:TextBox>
    </p>
    <p>
        Type</p>
    <p>
        <asp:DropDownList ID="TypeDropdown" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=PC-ITSIX61;Initial Catalog=Garage;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [ID], [Name] FROM [ProductType] ORDER BY [Name]"></asp:SqlDataSource>
    </p>
    <p>
        Price</p>
    <p>
        <asp:TextBox ID="Price" runat="server"></asp:TextBox>
    </p>
    <p>
        Image</p>
    <p>
        <asp:DropDownList ID="ImageDropdown" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Description</p>
    <p>
        <asp:TextBox ID="Description" runat="server" Height="62px" TextMode="MultiLine" Width="194px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click"/>
    </p>
    <p>
        <asp:Label ID="Results" runat="server" Text="Label"></asp:Label>
    </p>
</asp:Content>

