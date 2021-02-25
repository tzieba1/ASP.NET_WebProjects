<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="assignment1.Register" %>
<asp:Content ID="regsiterForm" ContentPlaceHolderID="MainContent" runat="server">
  <h2><%: Title %></h2>
  <div class="form-group container-fluid">
    <asp:Label ID="firstNameLabel" runat="server" Text="First Name" CssClass="col-sm-4 col-md-4 col-lg-4" ></asp:Label>
    <asp:TextBox ID="firstNameTextBox" runat="server" CssClass="col-sm-4 col-md-4 col-lg-4"></asp:TextBox>
    <asp:RequiredFieldValidator
      ID="RequiredFieldValidator1"
      runat="server"
      Text="Required."
      ControlToValidate="firstNameTextBox"
      CssClass="col-sm-4 col-md-4 col-lg-4"
      SetFocusOnError="true"
      ErrorMessage="First name is required.">
    </asp:RequiredFieldValidator>
    <asp:Literal ID="outputLiteral" runat="server"></asp:Literal>
  </div>
  <div class="form-group container-fluid">
    <asp:Label ID="lastNameLabel" runat="server" Text="Last Name" CssClass="col-sm-4 col-md-4 col-lg-4"></asp:Label>
    <asp:TextBox ID="lastNameTextBox" runat="server" CssClass="col-sm-4 col-md-4 col-lg-4"></asp:TextBox>
    <asp:RequiredFieldValidator
      ID="RequiredFieldValidator2"
      runat="server"
      Text="Required."
      ControlToValidate="lastNameTextBox"
      CssClass="col-sm-4 col-md-4 col-lg-4"
      SetFocusOnError="true"
      ErrorMessage="Last name is required.">
    </asp:RequiredFieldValidator>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
  </div>

  <div class="form-group container-fluid">
    <asp:Label ID="divisionLabel" runat="server" Text="Divison" CssClass="col-sm-4 col-md-4 col-lg-4"></asp:Label>
      <asp:DropDownList ID="divisionDropDownList" runat="server" CssClass="col-sm-4 col-md-4 col-lg-4" DataSourceID="SqlDataSource1" DataTextField="division_name" DataValueField="division_id"></asp:DropDownList>
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:HASCConnectionString %>' SelectCommand="SELECT division_name, division_id FROM divisions"></asp:SqlDataSource>
  </div>

  <div class="form-group container-fluid">
    <asp:Label ID="emailLabel" runat="server" Text="Email" CssClass="col-sm-4 col-md-4 col-lg-4"></asp:Label>
    <asp:TextBox ID="emailTextBox" runat="server" CssClass="col-sm-4 col-md-4 col-lg-4"></asp:TextBox>
    <asp:RequiredFieldValidator
      ID="RequiredFieldValidator3"
      runat="server"
      Text="Required."
      ControlToValidate="emailTextBox"
      CssClass="col-sm-4 col-md-4 col-lg-4"
      SetFocusOnError="true"
      ErrorMessage="Email is required.">
    </asp:RequiredFieldValidator>
    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
  </div>

  <div class="form-group container-fluid">
    <asp:Label ID="birthDateLabel" runat="server" Text="Birth date" CssClass="col-sm-4 col-md-4 col-lg-4"></asp:Label>
    <asp:TextBox ID="dateTextBox" runat="server" TextMode="Date" CssClass="col-sm-4 col-md-4 col-lg-4"></asp:TextBox>
    <asp:RequiredFieldValidator
      ID="RequiredFieldValidator4"
      runat="server"
      Text="Required."
      ControlToValidate="dateTextBox"
      CssClass="col-sm-4 col-md-4 col-lg-4"
      SetFocusOnError="true"
      ErrorMessage="Birth date is required.">
    </asp:RequiredFieldValidator>
    <asp:Literal ID="Literal3" runat="server"></asp:Literal>
  </div>

  <div class="form-group container-fluid">
      <asp:Label runat="server" Text=" " CssClass="col-sm-4 col-md-4 col-lg-4"></asp:Label>
      <asp:Button ID="submitButton" runat="server" Text="Submit"  CssClass="col-sm-4 col-md-4 col-lg-4" Width="100px"/>
      <asp:Button ID="cancelButton" runat="server" Text="Cancel" CausesValidation="false" CssClass="col-sm-4 col-md-4 col-lg-4" Width="100px" />
  </div>
  <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
  <asp:Literal ID="Literal4" runat="server"></asp:Literal>
</asp:Content>