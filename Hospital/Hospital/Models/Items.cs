using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    [Table("items")]
    public partial class Items
    {
        public Items()
        {
            PurchaseOrderLines = new HashSet<PurchaseOrderLines>();
        }

        [Key]
        [Column("item_id")]
        public int ItemId { get; set; }
        [Required]
        [Column("item_description")]
        [StringLength(30)]
        public string ItemDescription { get; set; }
        [Column("item_cost", TypeName = "decimal(9, 2)")]
        public decimal? ItemCost { get; set; }
        [Column("quantity_on_hand")]
        public int? QuantityOnHand { get; set; }
        [Column("usage_ytd")]
        public int? UsageYtd { get; set; }
        [Column("primary_vendor_id")]
        public int? PrimaryVendorId { get; set; }
        [Column("order_quantity")]
        public int? OrderQuantity { get; set; }
        [Column("order_point")]
        public int? OrderPoint { get; set; }

        [ForeignKey(nameof(PrimaryVendorId))]
        [InverseProperty(nameof(Vendors.Items))]
        public virtual Vendors PrimaryVendor { get; set; }
        [InverseProperty("Item")]
        public virtual ICollection<PurchaseOrderLines> PurchaseOrderLines { get; set; }
    }
}
