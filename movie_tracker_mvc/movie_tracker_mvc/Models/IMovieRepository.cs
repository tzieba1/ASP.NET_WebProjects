using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movie_tracker_mvc.Models
{
  public interface IMovieRepository
  {
    //One of the most important interfaces in .NET is IEnumerable because it represents a list of items with a specific ability.
    //IEnumberable returns a Collection of Objects that we can iterate over.
    //Many things render (return) IEnumberable.
    //Mmany things consume IEnumerable.
    IEnumerable<Movie> GetMovies();
    Movie GetMovie(int id);
    void CreateMovie(Movie movie);
    void EditMovie(Movie movie);
    void DeleteMovie(int id);
  }
}
