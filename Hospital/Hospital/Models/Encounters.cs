using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    [Table("encounters")]
    public partial class Encounters
    {
        [Key]
        [Column("patient_id")]
        public int PatientId { get; set; }
        [Key]
        [Column("physician_id")]
        public int PhysicianId { get; set; }
        [Key]
        [Column("encounter_date_time", TypeName = "datetime")]
        public DateTime EncounterDateTime { get; set; }
        [Column("notes")]
        [StringLength(250)]
        public string Notes { get; set; }

        [ForeignKey(nameof(PatientId))]
        [InverseProperty(nameof(Patients.Encounters))]
        public virtual Patients Patient { get; set; }
        [ForeignKey(nameof(PhysicianId))]
        [InverseProperty(nameof(Physicians.Encounters))]
        public virtual Physicians Physician { get; set; }
    }
}
