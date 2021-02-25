using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    [Table("unit_dose_orders")]
    public partial class UnitDoseOrders
    {
        [Key]
        [Column("unit_dose_order_id")]
        public int UnitDoseOrderId { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }
        [Column("medication_id")]
        public int MedicationId { get; set; }
        [Column("dosage")]
        [StringLength(20)]
        public string Dosage { get; set; }
        [Column("sig")]
        [StringLength(20)]
        public string Sig { get; set; }
        [Column("dosage_route")]
        [StringLength(10)]
        public string DosageRoute { get; set; }
        [Required]
        [Column("pharmacist_initials")]
        [StringLength(3)]
        public string PharmacistInitials { get; set; }
        [Column("entered_date", TypeName = "date")]
        public DateTime? EnteredDate { get; set; }

        [ForeignKey(nameof(MedicationId))]
        [InverseProperty(nameof(Medications.UnitDoseOrders))]
        public virtual Medications Medication { get; set; }
        [ForeignKey(nameof(PatientId))]
        [InverseProperty(nameof(Patients.UnitDoseOrders))]
        public virtual Patients Patient { get; set; }
    }
}
