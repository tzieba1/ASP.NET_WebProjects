using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    [Table("medications")]
    public partial class Medications
    {
        public Medications()
        {
            UnitDoseOrders = new HashSet<UnitDoseOrders>();
        }

        [Key]
        [Column("medication_id")]
        public int MedicationId { get; set; }
        [Required]
        [Column("medication_description")]
        [StringLength(25)]
        public string MedicationDescription { get; set; }
        [Column("medication_cost", TypeName = "decimal(9, 2)")]
        public decimal? MedicationCost { get; set; }
        [Column("package_size")]
        [StringLength(20)]
        public string PackageSize { get; set; }
        [Column("strength")]
        [StringLength(20)]
        public string Strength { get; set; }
        [Column("sig")]
        [StringLength(20)]
        public string Sig { get; set; }
        [Column("units_used_ytd")]
        public int? UnitsUsedYtd { get; set; }
        [Column("last_prescribed_date", TypeName = "date")]
        public DateTime? LastPrescribedDate { get; set; }

        [InverseProperty("Medication")]
        public virtual ICollection<UnitDoseOrders> UnitDoseOrders { get; set; }
    }
}
