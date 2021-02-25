using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assignment3.Models
{
  public class Divisions
  {
    [Key]
    public int Id { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
  }
}
