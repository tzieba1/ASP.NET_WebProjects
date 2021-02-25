using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    [Table("purchase_orders")]
    public partial class PurchaseOrders
    {
        public PurchaseOrders()
        {
            PurchaseOrderLines = new HashSet<PurchaseOrderLines>();
        }

        [Key]
        [Column("purchase_order_id")]
        public int PurchaseOrderId { get; set; }
        [Column("order_date", TypeName = "date")]
        public DateTime OrderDate { get; set; }
        [Column("department_id")]
        public int? DepartmentId { get; set; }
        [Column("vendor_id")]
        public int? VendorId { get; set; }
        [Column("total_amount", TypeName = "decimal(9, 2)")]
        public decimal? TotalAmount { get; set; }
        [Column("order_status")]
        [StringLength(10)]
        public string OrderStatus { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty(nameof(Departments.PurchaseOrders))]
        public virtual Departments Department { get; set; }
        [ForeignKey(nameof(VendorId))]
        [InverseProperty(nameof(Vendors.PurchaseOrders))]
        public virtual Vendors Vendor { get; set; }
        [InverseProperty("PurchaseOrder")]
        public virtual ICollection<PurchaseOrderLines> PurchaseOrderLines { get; set; }
    }
}
