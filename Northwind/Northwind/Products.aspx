<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Northwind.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <h2><%: Title %></h2>
  <p>Category: <asp:DropDownList 
                  ID="categoryDropDownList" 
                  runat="server" 
                  DataSourceID="categorySqlDataSource" 
                  DataTextField="CategoryName" 
                  DataValueField="CategoryID" 
                  AutoPostBack="True">
               </asp:DropDownList>
               <asp:SqlDataSource 
                 runat="server" 
                 ID="categorySqlDataSource" 
                 ConnectionString='<%$ ConnectionStrings:NorthwindConnectionString1 %>' 
                 SelectCommand="SELECT [CategoryID], [CategoryName] FROM [Categories]">
               </asp:SqlDataSource>
  </p>
  <asp:GridView ID="productsGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="productsSqlDataSource" EmptyDataText="There are no data records to display." AllowPaging="True" AllowSorting="True" CellPadding="4" CssClass="table-condensed" ForeColor="#333333" GridLines="None" OnRowDataBound="productsGridView_RowDataBound">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
      <asp:CommandField ShowEditButton="True" />
      <asp:BoundField DataField="ProductID" HeaderText="ID" ReadOnly="True" SortExpression="ProductID" />
      <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
      <asp:BoundField DataField="SupplierID" HeaderText="Supplier ID" SortExpression="SupplierID" />
      <asp:BoundField DataField="QuantityPerUnit" HeaderText="Quantity Per Unit" SortExpression="QuantityPerUnit" />
      <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" SortExpression="UnitPrice" DataFormatString="{0:c}">
        <ItemStyle HorizontalAlign="Right"></ItemStyle>
      </asp:BoundField>
      <asp:BoundField DataField="UnitsInStock" HeaderText="Units In Stock" SortExpression="UnitsInStock"></asp:BoundField>
      <asp:BoundField DataField="ReorderLevel" HeaderText="Reorder Level" SortExpression="ReorderLevel" />
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
  
  <asp:SqlDataSource 
    ID="productsSqlDataSource" 
    runat="server" 
    ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString1 %>" 
    DeleteCommand="DELETE FROM [Products] WHERE [ProductID] = @ProductID" 
    InsertCommand="INSERT INTO [Products] ([ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)" 
    SelectCommand="SELECT [ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued] FROM [Products] WHERE ([CategoryID] = @CategoryID) AND [Discontinued] = 'false'" 
    UpdateCommand="UPDATE [Products] SET [ProductName] = @ProductName, [SupplierID] = @SupplierID, [CategoryID] = @CategoryID, [QuantityPerUnit] = @QuantityPerUnit, [UnitPrice] = @UnitPrice, [UnitsInStock] = @UnitsInStock, [UnitsOnOrder] = @UnitsOnOrder, [ReorderLevel] = @ReorderLevel, [Discontinued] = @Discontinued WHERE [ProductID] = @ProductID">

    <DeleteParameters>
      <asp:Parameter Name="ProductID" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
      <asp:Parameter Name="ProductName" Type="String" />
      <asp:Parameter Name="SupplierID" Type="Int32" />
      <asp:Parameter Name="CategoryID" Type="Int32" />
      <asp:Parameter Name="QuantityPerUnit" Type="String" />
      <asp:Parameter Name="UnitPrice" Type="Decimal" />
      <asp:Parameter Name="UnitsInStock" Type="Int16" />
      <asp:Parameter Name="UnitsOnOrder" Type="Int16" />
      <asp:Parameter Name="ReorderLevel" Type="Int16" />
      <asp:Parameter Name="Discontinued" Type="Boolean" />
    </InsertParameters>
    <SelectParameters>
      <asp:ControlParameter ControlID="categoryDropDownList" PropertyName="SelectedValue" Name="CategoryID" Type="Int32"></asp:ControlParameter>
    </SelectParameters>
    <UpdateParameters>
      <asp:Parameter Name="ProductName" Type="String" />
      <asp:Parameter Name="SupplierID" Type="Int32" />
      <asp:Parameter Name="CategoryID" Type="Int32" />
      <asp:Parameter Name="QuantityPerUnit" Type="String" />
      <asp:Parameter Name="UnitPrice" Type="Decimal" />
      <asp:Parameter Name="UnitsInStock" Type="Int16" />
      <asp:Parameter Name="UnitsOnOrder" Type="Int16" />
      <asp:Parameter Name="ReorderLevel" Type="Int16" />
      <asp:Parameter Name="Discontinued" Type="Boolean" />
      <asp:Parameter Name="ProductID" Type="Int32" />
    </UpdateParameters>
  </asp:SqlDataSource>

</asp:Content>
