using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movie_tracker_mvc.Models
{
  public class MovieRepository : IMovieRepository
  {
    private static List<Movie> movies = new List<Movie>
    {
      //Not used after actual DB is implemented with a DbContext
      new Movie
      {
        Id = 1,
        Title = "Good Will Hunting",
        Genre = "Drama",
        DateSeen = new DateTime(2020,10,28),
        Rating = 9
      },
      new Movie
      {
        Id = 2,
        Title = "Austin Powers: Goldmember",
        DateSeen = new DateTime(2020,11,02),
        Genre = "Comedy",
        Rating = 6
      },
      new Movie
      {
        Id = 3,
        Title = "Aquaman",
        DateSeen = new DateTime(2020,11,06),
        Genre = "Action",
        Rating = 8
      }
    };
    public void CreateMovie(Movie movie)
    {
      var maxId = 0;
      if (movies.Count != 0)
      {
        maxId = movies.Max(m => m.Id);
      }
      movie.Id = maxId + 1;
      movies.Add(movie);
    }

    public void DeleteMovie(int id)
    {
      var index = movies.FindIndex(m => m.Id == id);
      movies.RemoveAt(index);
    }

    public void EditMovie(Movie movie)
    {
      var index = movies.FindIndex(m => m.Id == movie.Id);
      movies[index] = movie;
    }

    public Movie GetMovie(int id)
    {
      return movies.Find(m => m.Id == id);
    }

    public IEnumerable<Movie> GetMovies()
    {
      return movies;
    }
  }
}
