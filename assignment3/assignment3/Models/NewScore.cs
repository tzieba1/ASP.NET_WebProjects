using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assignment3.Models
{
  public class NewScore
  {
    [Key]
    public int Id { get; set; }
    public string Referee { get; set; }
    [DataType(DataType.Date)]
    public DateTime? Date { get; set; }
    public string Home { get; set; }
    public int HomeScore { get; set; }
    public string Away { get; set; }
    public int AwayScore { get; set; }
    public string Field { get; set; }
    public string GameNotes { get; set; }
  }
}
