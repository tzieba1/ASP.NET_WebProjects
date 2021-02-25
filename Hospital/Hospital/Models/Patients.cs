﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    [Table("patients")]
    public partial class Patients
    {
        public Patients()
        {
            Admissions = new HashSet<Admissions>();
            Encounters = new HashSet<Encounters>();
            UnitDoseOrders = new HashSet<UnitDoseOrders>();
        }

        [Key]
        [Column("patient_id")]
        public int PatientId { get; set; }
        [Column("first_name")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Column("last_name")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Column("gender")]
        [StringLength(1)]
        public string Gender { get; set; }
        [Column("birth_date", TypeName = "date")]
        public DateTime? BirthDate { get; set; }
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
        [Column("health_card_num")]
        public long? HealthCardNum { get; set; }
        [Column("allergies")]
        [StringLength(80)]
        public string Allergies { get; set; }
        [Column("patient_height", TypeName = "decimal(3, 0)")]
        public decimal? PatientHeight { get; set; }
        [Column("patient_weight", TypeName = "decimal(4, 0)")]
        public decimal? PatientWeight { get; set; }

        [ForeignKey(nameof(ProvinceId))]
        [InverseProperty(nameof(Provinces.Patients))]
        public virtual Provinces Province { get; set; }
        [InverseProperty("Patient")]
        public virtual ICollection<Admissions> Admissions { get; set; }
        [InverseProperty("Patient")]
        public virtual ICollection<Encounters> Encounters { get; set; }
        [InverseProperty("Patient")]
        public virtual ICollection<UnitDoseOrders> UnitDoseOrders { get; set; }
    }
}
