using assignment2.Controllers;
using assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace assignment2_test
{
  [TestCaseOrderer("assignment2_test.AlphabeticalOrderer", "assignment2_test")]
  public class UnitTest1
  {
    private ICarRepository carRepo;
    public UnitTest1()
    {
      carRepo = new CarRepository();
    }

    [Fact]
    public void A_Index_NoInput_ReturnsCars()
    {
      // ARRANGE
      var carsController = new CarsController(carRepo);

      // ACT
      var actionResult = carsController.Index();

      // ASSERT
      Assert.IsType<ViewResult>(actionResult);
      var viewResult = actionResult as ViewResult;
      Assert.IsType<List<Car>>(viewResult.Model);
      var cars = viewResult.Model as List<Car>;
      // Check the number of cars and a portion of every record and all fields.
      Assert.Equal(5, cars.Count);
      Assert.Equal(3, cars[2].Id);
      Assert.Equal("Chevrolet", cars[4].Make);
      Assert.Equal(new DateTime(2015, 01, 15), cars[0].PurchaseDate);
      Assert.Equal("Pearl", cars[1].Colour);
      Assert.Equal("Goodwood Green", cars[4].Colour);
      Assert.Equal(87, cars[3].Kilometres);
      Assert.Equal("RAM 1500", cars[1].Model);
      Assert.Equal("LaFerrari", cars[3].Model);
      Assert.Equal(2019, cars[2].Year);
    }

    [Fact]
    public void C_Create_Car_RedirectsToIndex()
    {
      // ARRANGE
      var carsController = new CarsController(carRepo);

      // ACT
      var actionResult = carsController.Create(
        new Car
        {
          Id = 6,
          Make = "Dodge",
          Model = "Viper",
          Colour = "GTS-R Blue",
          Year = 2018,
          PurchaseDate = new DateTime(2019, 06, 15),
          Kilometres = 326
        });
      // ASSERT
      Assert.IsType<RedirectToActionResult>(actionResult);
      var redirectToActionResult = actionResult as RedirectToActionResult;
      Assert.Equal("Index", redirectToActionResult.ActionName);

      // ACT (again)
      actionResult = carsController.Index();
      // ASSERT (again)
      Assert.IsType<ViewResult>(actionResult);
      var viewResult = actionResult as ViewResult;
      Assert.IsType<List<Car>>(viewResult.Model);
      var cars = viewResult.Model as List<Car>;
      // Check that there are 6 cars on the Index page after redirecting.
      Assert.Equal(6, cars.Count);
    }

    [Fact]
    public void B_Details_CarId_ReturnsCar()
    {
      // ARRANGE
      var carsController = new CarsController(carRepo);

      // ACT
      var actionResult = carsController.Details(4);

      // ASSERT
      Assert.IsType<ViewResult>(actionResult);
      var viewResult = actionResult as ViewResult;
      Assert.IsType<Car>(viewResult.Model);
      var car = viewResult.Model as Car;

      // Test all properties for the car corresponding to the actionResult.
      Assert.Equal(4, car.Id);
      Assert.Equal("Ferrari", car.Make);
      Assert.Equal("LaFerrari", car.Model);
      Assert.Equal("Ferrari Red", car.Colour);
      Assert.Equal(2018, car.Year);
      Assert.Equal(new DateTime(2020, 11, 07), car.PurchaseDate);
      Assert.Equal(87, car.Kilometres);
    }

    [Fact]
    public void D_Edit_Car_RedirectToDetails()
    {
      // ARRANGE
      var carsController = new CarsController(carRepo);

      // ACT - Edit View calls EditCar method from CarController, which implements EditCar from ICarRepository (replacing the car at the id with a new car).
      var actionResult = carsController.Edit(1,
        new Car
        {
          Id = 1,
          Make = "Toyota",
          Model = "Corolla",
          Colour = "Black",
          Year = 2010,
          PurchaseDate = new DateTime(2015, 01, 15),
          Kilometres = 109317
        });
      // ASSERT (check for redirection to Index)
      Assert.IsType<RedirectToActionResult>(actionResult);
      var redirectToActionResult = actionResult as RedirectToActionResult;
      Assert.Equal("Index", redirectToActionResult.ActionName);

      // ACT (again - for car Details)
      actionResult = carsController.Details(1);
      // ASSERT (again - for car Details)
      Assert.IsType<ViewResult>(actionResult);
      var viewResult = actionResult as ViewResult;
      Assert.IsType<Car>(viewResult.Model);
      var car = viewResult.Model as Car;
      // Test if edited changes persisted to the Index page after redirecting.
      Assert.Equal(109317, car.Kilometres);
      Assert.Equal("Black", car.Colour);
    }

    [Fact]
    public void E_Delete_Car_RedirectToIndex()
    {
      // ARRANGE
      var carsController = new CarsController(carRepo);

      // ACT
      var actionResult = carsController.Delete(6,null);

      // ASSERT (check for redirection to Index)
      Assert.IsType<RedirectToActionResult>(actionResult);
      var redirectToActionResult = actionResult as RedirectToActionResult;
      Assert.Equal("Index", redirectToActionResult.ActionName);

      // ACT (again)
      actionResult = carsController.Index();
      // ASSERT (again)
      Assert.IsType<ViewResult>(actionResult);
      var viewResult = actionResult as ViewResult;
      Assert.IsType<List<Car>>(viewResult.Model);
      var cars = viewResult.Model as List<Car>;
      // Check that there are 5 cars on the Index page after Delete
      Assert.Equal(5, cars.Count);

    }
  }
}
