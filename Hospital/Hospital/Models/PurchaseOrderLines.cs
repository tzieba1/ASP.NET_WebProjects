using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    [Table("purchase_order_lines")]
    public partial class PurchaseOrderLines
    {
        [Key]
        [Column("purchase_order_id")]
        public int PurchaseOrderId { get; set; }
        [Key]
        [Column("line_num")]
        public int LineNum { get; set; }
        [Column("item_id")]
        public int? ItemId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("unit_cost", TypeName = "decimal(9, 2)")]
        public decimal? UnitCost { get; set; }
        [Column("received")]
        public int? Received { get; set; }
        [Column("cancelled")]
        public int? Cancelled { get; set; }
        [Column("last_arrived_date", TypeName = "date")]
        public DateTime? LastArrivedDate { get; set; }

        [ForeignKey(nameof(ItemId))]
        [InverseProperty(nameof(Items.PurchaseOrderLines))]
        public virtual Items Item { get; set; }
        [ForeignKey(nameof(PurchaseOrderId))]
        [InverseProperty(nameof(PurchaseOrders.PurchaseOrderLines))]
        public virtual PurchaseOrders PurchaseOrder { get; set; }
    }
}
