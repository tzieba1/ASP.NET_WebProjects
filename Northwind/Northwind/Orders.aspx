<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Northwind.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <h2><%: Title %></h2>
  <p>Customer: <asp:DropDownList ID="customersDropDownList" runat="server" DataSourceID="customersSqlDataSource" DataTextField="CompanyName" DataValueField="CustomerID" AutoPostBack="True"></asp:DropDownList><asp:SqlDataSource runat="server" ID="customersSqlDataSource" ConnectionString='<%$ ConnectionStrings:NorthwindConnectionString1 %>' SelectCommand="SELECT [CustomerID], [CompanyName] FROM [Customers]"></asp:SqlDataSource>
  </p>
  <asp:GridView ID="ordersGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderID" DataSourceID="ordersSqlDataSource" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table-condensed">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
      <asp:CommandField ShowSelectButton="True"></asp:CommandField>
      <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate" DataFormatString="{0:d}"></asp:BoundField>
      <asp:BoundField DataField="ShippedDate" HeaderText="ShippedDate" SortExpression="ShippedDate" DataFormatString="{0:d}"></asp:BoundField>
      <asp:BoundField DataField="ShipVia" HeaderText="ShipVia" SortExpression="ShipVia"></asp:BoundField>
      <asp:BoundField DataField="Freight" HeaderText="Freight" SortExpression="Freight" DataFormatString="{0:c}"></asp:BoundField>
    </Columns>
    <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#E9E7E2" />
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
  </asp:GridView>
  <asp:SqlDataSource runat="server" ID="ordersSqlDataSource" ConnectionString='<%$ ConnectionStrings:NorthwindConnectionString1 %>' SelectCommand="SELECT [OrderID], [OrderDate], [ShippedDate], [ShipVia], [Freight] FROM [Orders] WHERE ([CustomerID] LIKE '%' + @CustomerID + '%')">
    <SelectParameters>
      <asp:ControlParameter ControlID="customersDropDownList" PropertyName="SelectedValue" Name="CustomerID" Type="String"></asp:ControlParameter>
    </SelectParameters>
  </asp:SqlDataSource>
  <asp:SqlDataSource ID="orderSqlDataSource" runat="server" ConnectionString='<%$ ConnectionStrings:NorthwindConnectionString1 %>'
    OldValuesParameterFormatString="original_{0}"
    SelectCommand="SELECT * FROM [Orders] WHERE ([OrderID] = @OrderID)" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [Orders] WHERE [OrderID] = @original_OrderID AND (([CustomerID] = @original_CustomerID) OR ([CustomerID] IS NULL AND @original_CustomerID IS NULL)) AND (([EmployeeID] = @original_EmployeeID) OR ([EmployeeID] IS NULL AND @original_EmployeeID IS NULL)) AND (([OrderDate] = @original_OrderDate) OR ([OrderDate] IS NULL AND @original_OrderDate IS NULL)) AND (([RequiredDate] = @original_RequiredDate) OR ([RequiredDate] IS NULL AND @original_RequiredDate IS NULL)) AND (([ShippedDate] = @original_ShippedDate) OR ([ShippedDate] IS NULL AND @original_ShippedDate IS NULL)) AND (([ShipVia] = @original_ShipVia) OR ([ShipVia] IS NULL AND @original_ShipVia IS NULL)) AND (([Freight] = @original_Freight) OR ([Freight] IS NULL AND @original_Freight IS NULL)) AND (([ShipName] = @original_ShipName) OR ([ShipName] IS NULL AND @original_ShipName IS NULL)) AND (([ShipAddress] = @original_ShipAddress) OR ([ShipAddress] IS NULL AND @original_ShipAddress IS NULL)) AND (([ShipCity] = @original_ShipCity) OR ([ShipCity] IS NULL AND @original_ShipCity IS NULL)) AND (([ShipRegion] = @original_ShipRegion) OR ([ShipRegion] IS NULL AND @original_ShipRegion IS NULL)) AND (([ShipPostalCode] = @original_ShipPostalCode) OR ([ShipPostalCode] IS NULL AND @original_ShipPostalCode IS NULL)) AND (([ShipCountry] = @original_ShipCountry) OR ([ShipCountry] IS NULL AND @original_ShipCountry IS NULL))" InsertCommand="INSERT INTO [Orders] ([CustomerID], [EmployeeID], [OrderDate], [RequiredDate], [ShippedDate], [ShipVia], [Freight], [ShipName], [ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], [ShipCountry]) VALUES (@CustomerID, @EmployeeID, @OrderDate, @RequiredDate, @ShippedDate, @ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry)" UpdateCommand="UPDATE [Orders] SET [CustomerID] = @CustomerID, [EmployeeID] = @EmployeeID, [OrderDate] = @OrderDate, [RequiredDate] = @RequiredDate, [ShippedDate] = @ShippedDate, [ShipVia] = @ShipVia, [Freight] = @Freight, [ShipName] = @ShipName, [ShipAddress] = @ShipAddress, [ShipCity] = @ShipCity, [ShipRegion] = @ShipRegion, [ShipPostalCode] = @ShipPostalCode, [ShipCountry] = @ShipCountry WHERE [OrderID] = @original_OrderID AND (([CustomerID] = @original_CustomerID) OR ([CustomerID] IS NULL AND @original_CustomerID IS NULL)) AND (([EmployeeID] = @original_EmployeeID) OR ([EmployeeID] IS NULL AND @original_EmployeeID IS NULL)) AND (([OrderDate] = @original_OrderDate) OR ([OrderDate] IS NULL AND @original_OrderDate IS NULL)) AND (([RequiredDate] = @original_RequiredDate) OR ([RequiredDate] IS NULL AND @original_RequiredDate IS NULL)) AND (([ShippedDate] = @original_ShippedDate) OR ([ShippedDate] IS NULL AND @original_ShippedDate IS NULL)) AND (([ShipVia] = @original_ShipVia) OR ([ShipVia] IS NULL AND @original_ShipVia IS NULL)) AND (([Freight] = @original_Freight) OR ([Freight] IS NULL AND @original_Freight IS NULL)) AND (([ShipName] = @original_ShipName) OR ([ShipName] IS NULL AND @original_ShipName IS NULL)) AND (([ShipAddress] = @original_ShipAddress) OR ([ShipAddress] IS NULL AND @original_ShipAddress IS NULL)) AND (([ShipCity] = @original_ShipCity) OR ([ShipCity] IS NULL AND @original_ShipCity IS NULL)) AND (([ShipRegion] = @original_ShipRegion) OR ([ShipRegion] IS NULL AND @original_ShipRegion IS NULL)) AND (([ShipPostalCode] = @original_ShipPostalCode) OR ([ShipPostalCode] IS NULL AND @original_ShipPostalCode IS NULL)) AND (([ShipCountry] = @original_ShipCountry) OR ([ShipCountry] IS NULL AND @original_ShipCountry IS NULL))">
    <DeleteParameters>
      <asp:Parameter Name="original_OrderID" Type="Int32"></asp:Parameter>
      <asp:Parameter Name="original_CustomerID" Type="String"></asp:Parameter>
      <asp:Parameter Name="original_EmployeeID" Type="Int32"></asp:Parameter>
      <asp:Parameter Name="original_OrderDate" Type="DateTime"></asp:Parameter>
      <asp:Parameter Name="original_RequiredDate" Type="DateTime"></asp:Parameter>
      <asp:Parameter Name="original_ShippedDate" Type="DateTime"></asp:Parameter>
      <asp:Parameter Name="original_ShipVia" Type="Int32"></asp:Parameter>
      <asp:Parameter Name="original_Freight" Type="Decimal"></asp:Parameter>
      <asp:Parameter Name="original_ShipName" Type="String"></asp:Parameter>
      <asp:Parameter Name="original_ShipAddress" Type="String"></asp:Parameter>
      <asp:Parameter Name="original_ShipCity" Type="String"></asp:Parameter>
      <asp:Parameter Name="original_ShipRegion" Type="String"></asp:Parameter>
      <asp:Parameter Name="original_ShipPostalCode" Type="String"></asp:Parameter>
      <asp:Parameter Name="original_ShipCountry" Type="String"></asp:Parameter>
    </DeleteParameters>
    <InsertParameters>
      <asp:Parameter Name="CustomerID" Type="String"></asp:Parameter>
      <asp:Parameter Name="EmployeeID" Type="Int32"></asp:Parameter>
      <asp:Parameter Name="OrderDate" Type="DateTime"></asp:Parameter>
      <asp:Parameter Name="RequiredDate" Type="DateTime"></asp:Parameter>
      <asp:Parameter Name="ShippedDate" Type="DateTime"></asp:Parameter>
      <asp:Parameter Name="ShipVia" Type="Int32"></asp:Parameter>
      <asp:Parameter Name="Freight" Type="Decimal"></asp:Parameter>
      <asp:Parameter Name="ShipName" Type="String"></asp:Parameter>
      <asp:Parameter Name="ShipAddress" Type="String"></asp:Parameter>
      <asp:Parameter Name="ShipCity" Type="String"></asp:Parameter>
      <asp:Parameter Name="ShipRegion" Type="String"></asp:Parameter>
      <asp:Parameter Name="ShipPostalCode" Type="String"></asp:Parameter>
      <asp:Parameter Name="ShipCountry" Type="String"></asp:Parameter>
    </InsertParameters>
    <SelectParameters>
      <asp:ControlParameter ControlID="ordersGridView" PropertyName="SelectedValue" Name="OrderID" Type="Int32"></asp:ControlParameter>
    </SelectParameters>
    <UpdateParameters>
      <asp:Parameter Name="CustomerID" Type="String"></asp:Parameter>
      <asp:Parameter Name="EmployeeID" Type="Int32"></asp:Parameter>
      <asp:Parameter Name="OrderDate" Type="DateTime"></asp:Parameter>
      <asp:Parameter Name="RequiredDate" Type="DateTime"></asp:Parameter>
      <asp:Parameter Name="ShippedDate" Type="DateTime"></asp:Parameter>
      <asp:Parameter Name="ShipVia" Type="Int32"></asp:Parameter>
      <asp:Parameter Name="Freight" Type="Decimal"></asp:Parameter>
      <asp:Parameter Name="ShipName" Type="String"></asp:Parameter>
      <asp:Parameter Name="ShipAddress" Type="String"></asp:Parameter>
      <asp:Parameter Name="ShipCity" Type="String"></asp:Parameter>
      <asp:Parameter Name="ShipRegion" Type="String"></asp:Parameter>
      <asp:Parameter Name="ShipPostalCode" Type="String"></asp:Parameter>
      <asp:Parameter Name="ShipCountry" Type="String"></asp:Parameter>
      <asp:Parameter Name="original_OrderID" Type="Int32"></asp:Parameter>
      <asp:Parameter Name="original_CustomerID" Type="String"></asp:Parameter>
      <asp:Parameter Name="original_EmployeeID" Type="Int32"></asp:Parameter>
      <asp:Parameter Name="original_OrderDate" Type="DateTime"></asp:Parameter>
      <asp:Parameter Name="original_RequiredDate" Type="DateTime"></asp:Parameter>
      <asp:Parameter Name="original_ShippedDate" Type="DateTime"></asp:Parameter>
      <asp:Parameter Name="original_ShipVia" Type="Int32"></asp:Parameter>
      <asp:Parameter Name="original_Freight" Type="Decimal"></asp:Parameter>
      <asp:Parameter Name="original_ShipName" Type="String"></asp:Parameter>
      <asp:Parameter Name="original_ShipAddress" Type="String"></asp:Parameter>
      <asp:Parameter Name="original_ShipCity" Type="String"></asp:Parameter>
      <asp:Parameter Name="original_ShipRegion" Type="String"></asp:Parameter>
      <asp:Parameter Name="original_ShipPostalCode" Type="String"></asp:Parameter>
      <asp:Parameter Name="original_ShipCountry" Type="String"></asp:Parameter>
    </UpdateParameters>
  </asp:SqlDataSource>
  
  <br/>
  <asp:DetailsView ID="orderDetailsView" runat="server" Height="50px" CssClass="table-condensed" DataKeyNames="OrderID" DataSourceID="orderSqlDataSource" CellPadding="4" ForeColor="#333333" GridLines="None">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>

    <CommandRowStyle BackColor="#E2DED6" Font-Bold="True"></CommandRowStyle>

    <EditRowStyle BackColor="#999999"></EditRowStyle>

    <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True"></FieldHeaderStyle>
    <Fields>
      <asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True" InsertVisible="False" SortExpression="OrderID"></asp:BoundField>
      <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" SortExpression="CustomerID"></asp:BoundField>
      <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" SortExpression="EmployeeID"></asp:BoundField>
      <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate"></asp:BoundField>
      <asp:BoundField DataField="RequiredDate" HeaderText="RequiredDate" SortExpression="RequiredDate"></asp:BoundField>
      <asp:BoundField DataField="ShippedDate" HeaderText="ShippedDate" SortExpression="ShippedDate"></asp:BoundField>
      <asp:BoundField DataField="ShipVia" HeaderText="ShipVia" SortExpression="ShipVia"></asp:BoundField>
      <asp:BoundField DataField="Freight" HeaderText="Freight" SortExpression="Freight"></asp:BoundField>
      <asp:BoundField DataField="ShipName" HeaderText="ShipName" SortExpression="ShipName"></asp:BoundField>
      <asp:BoundField DataField="ShipAddress" HeaderText="ShipAddress" SortExpression="ShipAddress"></asp:BoundField>
      <asp:BoundField DataField="ShipCity" HeaderText="ShipCity" SortExpression="ShipCity"></asp:BoundField>
      <asp:BoundField DataField="ShipRegion" HeaderText="ShipRegion" SortExpression="ShipRegion"></asp:BoundField>
      <asp:BoundField DataField="ShipPostalCode" HeaderText="ShipPostalCode" SortExpression="ShipPostalCode"></asp:BoundField>
      <asp:BoundField DataField="ShipCountry" HeaderText="ShipCountry" SortExpression="ShipCountry"></asp:BoundField>
      <asp:CommandField ShowEditButton="True"></asp:CommandField>
    </Fields>
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

    <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

    <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
  </asp:DetailsView>
</asp:Content>
