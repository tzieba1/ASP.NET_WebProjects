using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment3.Models
{
  public class DivisionsDataContext : DbContext, IDivisionsRepository
  {
    public DbSet<Divisions> Divisions { get; set; }

    public DivisionsDataContext(DbContextOptions<DivisionsDataContext> options) : base(options)
    {
      //Database.EnsureCreated();
    }
    public IEnumerable<Divisions> GetDivisions()
    {
      throw new NotImplementedException();
    }
  }
}
