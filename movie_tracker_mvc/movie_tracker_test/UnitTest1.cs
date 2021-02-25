using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using movie_tracker_mvc.Controllers;
using movie_tracker_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace movie_tracker_test
{

  [TestCaseOrderer("movie_tracker_test.AlphabeticalOrderer", "movie_tracker_test")]
  public class UnitTest1
  {
    //private IMovieRepository db;
    private MovieDataContext db;

    public UnitTest1()
    {
      var options = new DbContextOptionsBuilder<MovieDataContext>().UseInMemoryDatabase(databaseName: "movie_tests").Options;

      //db = MovieRepository();
      db = new MovieDataContext(options);

      db.Movies.AddRange(
        new Movie
        {
          Title = "The Dark Knight",
          DateSeen = new DateTime(2020, 5, 20),
          Genre = "Action",
          Rating = 9 
        },
        new Movie
        {
          Title = "Dude Where's My Car",
          DateSeen = new DateTime(2005, 4, 16),
          Genre = "Comedy",
          Rating = 8
        }
      );

      db.SaveChanges();
    }

    [Fact]
    public void A_Index_NoInput_ReturnsMovies()
    {
      // Arrange
      var moviesController = new MoviesController(db);

      // Act
      var actionResult = moviesController.Index();

      // Assert
      Assert.IsType<ViewResult>(actionResult);
      var viewResult = actionResult as ViewResult;
      
      //Prior to testing with DB implemented is commented out
      //Assert.IsType<List<Movie>>(viewResult.Model);
      Assert.IsType<InternalDbSet<Movie>>(viewResult.Model);
      var dbMovies = viewResult.Model as InternalDbSet<Movie>;

      //var movies = viewResult.Model as List<Movie>;
      var movies = dbMovies.ToList();


      // Check the number of movies and a portion of every record and all fields.
      //THESE CORRESPOND TO THE INTERNAL MEMORY DB ONLY (previous deleted for testing local DB in MovieRepository)
      Assert.Equal(2, movies.Count);
      Assert.Equal(2, movies[1].Id);
      Assert.Equal("The Dark Knight", movies[0].Title);
      Assert.Equal(new DateTime(2020,5,20), movies[0].DateSeen);
      Assert.Equal("Comedy", movies[1].Genre);
      Assert.Equal(9, movies[0].Rating);
    }

    [Fact]
    public void C_Create_Movie_RedirectsToIndex()
    {
      // Arrange
      var moviesController = new MoviesController(db);

      // Act
      var actionResult = moviesController.Create(
        new Movie
        {
          Title = "Casablanca",
          DateSeen = DateTime.Now.Date,
          Genre = "Drama",
          Rating = 4
        });
      ;

      // Assert
      Assert.IsType<RedirectToActionResult>(actionResult);
      var redirectToActionResult = actionResult as RedirectToActionResult;
      Assert.Equal("Index", redirectToActionResult.ActionName);
    }

    [Fact]
    public void B_Details_MovieId_ReturnsMovie()
    {
      // Arrange
      var moviesController = new MoviesController(db);

      // Act
      var actionResult = moviesController.Details(2);

      // Assert
      Assert.IsType<ViewResult>(actionResult);
      var viewResult = actionResult as ViewResult;
      Assert.IsType<Movie>(viewResult.Model);
      var movie = viewResult.Model as Movie;

      // Test all properties for the movie corresponding to the actionResult.
      //COMMENTED OUT PORTION CORRESPONDS TO LOCAL MovieRepository TESTING
      //Assert.Equal(1, movie.Id);
      //Assert.Equal("Good Will Hunting", movie.Title);
      //Assert.Equal(new DateTime(2020, 10, 28), movie.DateSeen);
      //Assert.Equal("Drama", movie.Genre);
      //Assert.Equal(9, movie.Rating);
      Assert.Equal(2, movie.Id);
      Assert.Equal("Dude Where's My Car", movie.Title);
      Assert.Equal(new DateTime(2005, 4, 16), movie.DateSeen);
      Assert.Equal("Comedy", movie.Genre);
      Assert.Equal(8, movie.Rating);
    }
  }
}
