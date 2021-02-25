using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movie_tracker_mvc.Models;

namespace movie_tracker_mvc.Controllers
{
  public class MoviesController : Controller
  {
/*    private static List<Movie> movies = new List<Movie>
    {
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
    };*/

    //private MovieRepository db;
    private IMovieRepository db;

    public MoviesController(/*NEW*/IMovieRepository movieRepository):base()
    {
      //db = new MovieRepository();
      db = movieRepository;
    }

    // GET: Movies
    public ActionResult Index()
    {
      //return View(movies);
      return View(db.GetMovies());
    }

    // GET: Movies/Details/5
    public ActionResult Details(int id)
    {
      //var movie = movies.Find(m => m.Id == id);
      var movie = db.GetMovie(id);
      //Error handling
      if (movie == null)
      {
        return View("Error",
          new ErrorViewModel
          {
            RequestId = id.ToString(),
            Description = $"Unable to find movie with id={id}."
          }); ;
      }
      return View(movie);
    }

    // GET: Movies/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Movies/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Movie movie)
    {
      try
      {
        if(ModelState.IsValid)
        {
          /* var maxId = 0;

           if (movies.Count != 0)
           {
             maxId = movies.Max(movies => movies.Id);
           }
           maxId= maxId + 1;
           movies.Add(movie);*/
          db.CreateMovie(movie);
          return RedirectToAction(nameof(Index));
        }
        else
        {
          return View(movie);
        }
      }
      catch(Exception ex)
      {
        return View("Error", 
          new ErrorViewModel
          {
            RequestId = "0",
            Description = $"Exception Message: {ex.Message}"
          });
      }
    }

    // GET: Movies/Edit/5
    public ActionResult Edit(int id)
    {
      //var movie = movies.Find(m => m.Id == id);
      var movie = db.GetMovie(id);
      //Error handling
      if (movie == null)
      {
        return View("Error",
          new ErrorViewModel
          {
            RequestId = id.ToString(),
            Description = $"Unable to find movie with id={id}."
          }); ;
      }
      return View(movie);
    }

    // POST: Movies/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(/*int id,*/ Movie movie)
    {
      try
      {
        if (ModelState.IsValid)
        {
          /*          var index = movies.FindIndex(m => m.Id == id);
                    movies[index] = movie;*/
          db.EditMovie(movie);
          return RedirectToAction(nameof(Index));
        }
        else
        {
          return View(movie);
        }
        
      }
      catch
      {
        return View();
      }
    }

    // GET: Movies/Delete/5
    public ActionResult Delete(int id)
    {
      //var movie = movies.Find(m => m.Id == id);
      var movie = db.GetMovie(id);
      //Error handling
      if (movie == null)
      {
        return View("Error",
          new ErrorViewModel
          {
            RequestId = id.ToString(),
            Description = $"Unable to find movie with id={id}."
          }); ;
      }
      return View(movie);
    }

    // POST: Movies/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
      try
      {
        /*var index = movies.FindIndex(m => m.Id == id);
        movies.RemoveAt(index);*/
        db.DeleteMovie(id);
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }
  }
}