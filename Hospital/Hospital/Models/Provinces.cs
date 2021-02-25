using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    [Table("provinces")]
    public partial class Provinces
    {
        public Provinces()
        {
            Patients = new HashSet<Patients>();
            Vendors = new HashSet<Vendors>();
        }

        [Key]
        [Column("province_id")]
        [StringLength(2)]
        public string ProvinceId { get; set; }
        [Required]
        [Column("province_name")]
        [StringLength(30)]
        public string ProvinceName { get; set; }

        [InverseProperty("Province")]
        public virtual ICollection<Patients> Patients { get; set; }
        [InverseProperty("Province")]
        public virtual ICollection<Vendors> Vendors { get; set; }
    }
}
