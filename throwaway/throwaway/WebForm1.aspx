<%@ Page Title="Page 1" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="throwaway.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h2><%: Title %></h2>
  <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
  &nbsp;
  <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
