using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    [Table("physicians")]
    public partial class Physicians
    {
        public Physicians()
        {
            Admissions = new HashSet<Admissions>();
            Encounters = new HashSet<Encounters>();
        }

        [Key]
        [Column("physician_id")]
        public int PhysicianId { get; set; }
        [Column("first_name")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Column("last_name")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Column("specialty")]
        [StringLength(25)]
        public string Specialty { get; set; }
        [Column("phone")]
        [StringLength(15)]
        public string Phone { get; set; }
        [Column("ohip_registration")]
        public int? OhipRegistration { get; set; }

        [InverseProperty("AttendingPhysician")]
        public virtual ICollection<Admissions> Admissions { get; set; }
        [InverseProperty("Physician")]
        public virtual ICollection<Encounters> Encounters { get; set; }
    }
}
