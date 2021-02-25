using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movie_tracker_mvc.Models
{
  public class MovieDataContext : DbContext, IMovieRepository
  {
    public DbSet<Movie> Movies { get; set; }

    public MovieDataContext(DbContextOptions<MovieDataContext> options) :  base(options)
    {
      //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Movie>().HasData(
        new Movie
        {
          Id = 1,
          Title = "Good Will Hunting",
          Genre = "Drama",
          DateSeen = new DateTime(2020, 10, 28),
          Rating = 9
        },
        new Movie
        {
          Id = 2,
          Title = "Austin Powers: Goldmember",
          DateSeen = new DateTime(2020, 11, 02),
          Genre = "Comedy",
          Rating = 6
        },
        new Movie
        {
          Id = 3,
          Title = "Aquaman",
          DateSeen = new DateTime(2020, 11, 06),
          Genre = "Action",
          Rating = 8
        }
      );
    }

    public IEnumerable<Movie> GetMovies()
    {
      return Movies;
    }

    public Movie GetMovie(int id)
    {
      return Movies.Find(id);
    }

    public void CreateMovie(Movie movie)
    {
      Movies.Add(movie);
      SaveChanges();
    }

    public void EditMovie(Movie movie)
    {
      Movies.Update(movie);
      SaveChanges();
    }

    public void DeleteMovie(int id)
    {
      var movie = GetMovie(id);
      Movies.Remove(movie);
      SaveChanges();
    }
  }
}
