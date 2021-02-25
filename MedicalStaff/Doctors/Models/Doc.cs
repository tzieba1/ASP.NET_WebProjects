using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctors.Models
{
  public class Doc
  {
    public int physicianId { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string specialty { get; set; }
    public string phone { get; set; }
    public int ohipRegistration { get; set; }
  }

}
