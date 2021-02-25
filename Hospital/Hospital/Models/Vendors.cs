using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    [Table("vendors")]
    public partial class Vendors
    {
        public Vendors()
        {
            Items = new HashSet<Items>();
            PurchaseOrders = new HashSet<PurchaseOrders>();
        }

        [Key]
        [Column("vendor_id")]
        public int VendorId { get; set; }
        [Required]
        [Column("vendor_name")]
        [StringLength(30)]
        public string VendorName { get; set; }
        [Column("street_address")]
        [StringLength(30)]
        public string StreetAddress { get; set; }
        [Column("city")]
        [StringLength(30)]
        public string City { get; set; }
        [Column("province_id")]
        [StringLength(2)]
        public string ProvinceId { get; set; }
        [Column("postal_code")]
        [StringLength(7)]
        public string PostalCode { get; set; }
        [Column("contact_first_name")]
        [StringLength(30)]
        public string ContactFirstName { get; set; }
        [Column("contact_last_name")]
        [StringLength(30)]
        public string ContactLastName { get; set; }
        [Column("purchases_ytd", TypeName = "decimal(9, 2)")]
        public decimal? PurchasesYtd { get; set; }

        [ForeignKey(nameof(ProvinceId))]
        [InverseProperty(nameof(Provinces.Vendors))]
        public virtual Provinces Province { get; set; }
        [InverseProperty("PrimaryVendor")]
        public virtual ICollection<Items> Items { get; set; }
        [InverseProperty("Vendor")]
        public virtual ICollection<PurchaseOrders> PurchaseOrders { get; set; }
    }
}
