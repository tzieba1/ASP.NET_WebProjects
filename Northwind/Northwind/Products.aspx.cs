using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Northwind
{
  public partial class Products : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Highlight any rows that have fewer than 10 items in stock,
    /// </summary>
    /// <param name="sender">productsGridView</param>
    /// <param name="e">Event data</param>
    protected void productsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        var unitsInStock = (short)DataBinder.Eval(e.Row.DataItem, "UnitsInStock");

        if (unitsInStock < 10)
        {
          e.Row.BackColor = System.Drawing.Color.Yellow;
        }// (unitsInStock < 10) 
      }// (e.Row.RowType == DataControlRowType.DataRow)
    }
  }
}