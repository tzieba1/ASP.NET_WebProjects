<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="assignment1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Your contact page.</h3>
    <address>
        1600 Pennsylvania Avenue NW<br />
        Washington, DC 20500<br />
        United States<br />
        <abbr title="Phone">P:</abbr>
        +1 202-456-1111
    </address>

    <address>
        <strong>Mohawk Email:</strong>   <a href="mailto:tommy.zieba@mohawkcollege.ca">tommy.zieba@mohawkcollege.ca</a>
    </address>
</asp:Content>
