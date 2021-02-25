using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movie_tracker_mvc.Models
{
  public class Movie
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [DataType(DataType.Date)]
    [Display(Name = "Date Seen")]
    public DateTime? DateSeen { get; set; }
    public string Genre { get; set; }
    [Range(1,10)]
    public int? Rating { get; set; }
  }
}
