using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    [Table("departments")]
    public partial class Departments
    {
        public Departments()
        {
            PurchaseOrders = new HashSet<PurchaseOrders>();
        }

        [Key]
        [Column("department_id")]
        public int DepartmentId { get; set; }
        [Required]
        [Column("department_name")]
        [StringLength(30)]
        public string DepartmentName { get; set; }
        [Column("manager_first_name")]
        [StringLength(30)]
        public string ManagerFirstName { get; set; }
        [Column("manager_last_name")]
        [StringLength(30)]
        public string ManagerLastName { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<PurchaseOrders> PurchaseOrders { get; set; }
    }
}
