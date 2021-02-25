<%@ Page Title="Enter a New Score" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewScore.aspx.cs" Inherits="assignment1.NewScore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <h2><%: Title %></h2>
  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:HASCConnectionString %>'  SelectCommand="SELECT games.game_id, games.game_date, games.field, games.home_team_id, games.home_team_score, games.away_team_id, games.away_team_score, games.game_notes, games.referee_id FROM games WHERE games.[referee_id] = @referee_id AND (games.home_team_score IS NULL) AND (games.away_team_score IS NULL)" UpdateCommand="UPDATE games SET home_team_score = @HomeTeamScore, away_team_score = @AwayTeamScore, game_notes = @GameNotes WHERE game_id = @GameID">
    <SelectParameters>
      <asp:ControlParameter Name="referee_id" ControlID="refereeDropDownList" PropertyName="Text" Type="Int16"/>
    </SelectParameters>
    <UpdateParameters>
      <asp:Parameter Name="HomeTeamScore"></asp:Parameter>
      <asp:Parameter Name="AwayTeamScore"></asp:Parameter>
      <asp:Parameter Name="GameNotes"></asp:Parameter>
      <asp:Parameter Name="GameID"></asp:Parameter>
    </UpdateParameters>
  </asp:SqlDataSource>
  <asp:Label ID="RefereeLabel" runat="server" Text="Label">Referee:</asp:Label>
  <asp:DropDownList ID="refereeDropDownList" runat="server" DataSourceID="SqlDataSource2" DataTextField="referee_full_name" DataValueField="person_ID" AutoPostBack="true"></asp:DropDownList>
  <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:HASCConnectionString %>' SelectCommand="SELECT persons.person_ID, CONCAT(persons.first_name, ' ', persons.last_name) AS referee_full_name FROM persons WHERE persons.referee = 1"></asp:SqlDataSource>
  <asp:GridView CssClass="p-3" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="game_id" DataSourceID="SqlDataSource1" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
    <Columns>
      <asp:CommandField ShowEditButton="True"></asp:CommandField>
      <asp:BoundField DataField="game_id" HeaderText="ID" ReadOnly="True" SortExpression="game_id"></asp:BoundField>
      <asp:BoundField DataField="game_date" HeaderText="Date" SortExpression="game_date" DataFormatString="{0:d}"></asp:BoundField>
      <asp:BoundField DataField="field" HeaderText="Field" SortExpression="field"></asp:BoundField>
      <asp:BoundField DataField="home_team_id" HeaderText="Home Team ID" SortExpression="home_team_id"></asp:BoundField>
      <asp:BoundField DataField="home_team_score" HeaderText="Score" SortExpression="home_team_score"></asp:BoundField>
      <asp:BoundField DataField="away_team_id" HeaderText="Away Team ID" SortExpression="away_team_id"></asp:BoundField>
      <asp:BoundField DataField="away_team_score" HeaderText="Score" SortExpression="away_team_score"></asp:BoundField>
      <asp:BoundField DataField="game_notes" HeaderText="Game Notes" SortExpression="game_notes"></asp:BoundField>
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
