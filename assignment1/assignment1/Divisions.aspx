<%@ Page Title="Divisions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Divisions.aspx.cs" Inherits="assignment1.Divisions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <h2><%: Title %></h2>
  <h3>HASC features the following divisions.</h3>
  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:HASCConnectionString %>' SelectCommand="SELECT [division_name] AS Division FROM [divisions] ORDER BY [division_name] ASC"></asp:SqlDataSource>
  <asp:GridView CssClass="p-4" ID="GridView1" runat="server" DataSourceID="SqlDataSource1" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
    <FooterStyle BackColor="#CCCCCC"></FooterStyle>

    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"></HeaderStyle>

    <PagerStyle HorizontalAlign="Left" BackColor="#CCCCCC" ForeColor="Black"></PagerStyle>

    <RowStyle BackColor="White"></RowStyle>

    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

    <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

    <SortedAscendingHeaderStyle BackColor="#808080"></SortedAscendingHeaderStyle>

    <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

    <SortedDescendingHeaderStyle BackColor="#383838"></SortedDescendingHeaderStyle>
  </asp:GridView>
  <p>Age is determined as of March 1 of each year.</p>
</asp:Content>
