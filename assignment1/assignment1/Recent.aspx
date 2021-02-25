<%@ Page Title="Recent Scores" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recent.aspx.cs" Inherits="assignment1.Recent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <h2><%: Title %></h2>
  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:HASCConnectionString %>' SelectCommand="SELECT TOP (10) game.game_date, away.team_name, game.away_team_score, home.team_name AS Expr1, game.home_team_score FROM games AS game INNER JOIN teams AS away ON away.team_id = game.away_team_id INNER JOIN teams AS home ON home.team_id = game.home_team_id WHERE (game.home_team_score IS NOT NULL) AND (game.away_team_score IS NOT NULL) ORDER BY game.game_date DESC"></asp:SqlDataSource>
  <asp:GridView CssClass="p-4" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="3" CellSpacing="2" ForeColor="Black" Height="254px" Width="359px">
    <Columns>
      <asp:BoundField DataField="game_date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:d}" ></asp:BoundField>
      <asp:BoundField DataField="team_name" HeaderText="Away" SortExpression="Away"></asp:BoundField>
      <asp:BoundField DataField="away_team_score" HeaderText="Score" SortExpression="Away Score"></asp:BoundField>
      <asp:BoundField DataField="Expr1" HeaderText="Home" SortExpression="Home"></asp:BoundField>
      <asp:BoundField DataField="home_team_score" HeaderText="Score" SortExpression="Home Score"></asp:BoundField>
    </Columns>
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
</asp:Content>
