using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assignment2.Models
{
  public class Car
  {
    [Key]
    public int Id{ get; set; }
    [Required]
    public string Make { get; set; }
    [Required]
    public string Model { get; set; }
    [Required]
    public string Colour { get; set; }
    public int Year { get; set; }
    [DataType(DataType.Date)]
    [Display(Name = "Purchase Date")]
    public DateTime PurchaseDate { get; set; }
    [Range(0,999999)]
    [DisplayFormat(DataFormatString ="{0:n0}") ]
    public int Kilometres { get; set; }
  }
}
