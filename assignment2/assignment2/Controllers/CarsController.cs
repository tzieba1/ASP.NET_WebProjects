using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment2.Controllers
{
  public class CarsController : Controller
  {
    private ICarRepository carRepo;
    public CarsController(ICarRepository carRepository) : base()
    {
      carRepo = carRepository;
    }
    // GET: Cars
    public ActionResult Index()
    {
      return View(carRepo.GetCars());
    }

    // GET: Cars/Details/5
    public ActionResult Details(int id)
    {
      var car = carRepo.GetCar(id);
      if (car ==  null)
      {
        return View("Error",
          new ErrorViewModel
          {
          RequestId = id.ToString(),
          Description = $"Unable to find a car with id={id}"
        });
      }
      return View(car);
    }

    // GET: Cars/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Cars/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Car car)
    {
      try
      {
       if(ModelState.IsValid)
        {
          carRepo.CreateCar(car);
          return RedirectToAction(nameof(Index));
        }
       else
        {
          return View(car);
        }
      }
      catch (Exception ex)
      {
        return View("Error", 
          new ErrorViewModel
          {
            RequestId = "0",
            Description = $"Esception message: '{ex.Message}'"
          });
      }
    }

    // GET: Cars/Edit/5
    public ActionResult Edit(int id)
    {
      var car = carRepo.GetCar(id);
      if (car == null)
      {
        return View("Error",
          new ErrorViewModel
          {
            RequestId = id.ToString(),
            Description = $"Unable to find a car with id={id}"
          });
      }
      return View(car);
    }

    // POST: Cars/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Car car)
    {
      try
      {
        if(ModelState.IsValid)
        {
          carRepo.EditCar(car);
          return RedirectToAction(nameof(Index));
        }
        else
        {
          return View(car);
        }
      }
      catch
      {
        return View();
      }
    }

    // GET: Cars/Delete/5
    public ActionResult Delete(int id)
    {
      var car = carRepo.GetCar(id);
      if(car == null)
      {
        return View("Error",
          new ErrorViewModel
          {
            RequestId = id.ToString(),
            Description = $"Unable to find a car with id={id}"
          });
      }
      return View(car);
    }

    // POST: Cars/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Car car)
    {
      try
      {
        carRepo.DeleteCar(id);
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }
  }
}