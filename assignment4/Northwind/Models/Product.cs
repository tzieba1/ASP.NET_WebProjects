using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{  public class Product
  {
    [DisplayName("Id")]
    public int productId { get; set; }
    [DisplayName("Name")]
    public string productName { get; set; }
    [DisplayName("Supplier Id")]
    public int supplierId { get; set; }
    [DisplayName("Category")]
    public int categoryId { get; set; }
    [DisplayName("Quantity Per Unit")]
    public string quantityPerUnit { get; set; }
    [DisplayFormat(DataFormatString = "{0:F2}")]
    [DisplayName("Unit Price")]
    public double unitPrice { get; set; }
    [DisplayName("In Stock")]
    public int unitsInStock { get; set; }
    [DisplayName("On Order")]
    public int unitsOnOrder { get; set; }
    [DisplayName("Reorder Level")]
    public int reorderLevel { get; set; }
    [DisplayName("Discontinued")]
    public bool discontinued { get; set; }
  }

}
