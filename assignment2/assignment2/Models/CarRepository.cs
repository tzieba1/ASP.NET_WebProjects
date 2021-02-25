using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment2.Models
{
  public class CarRepository : ICarRepository
  {
    private static List<Car> cars = new List<Car>
    {
      new Car
      {
        Id = 1,
        Make = "Toyota",
        Model = "Corolla",
        Colour = "White",
        Year = 2010,
        PurchaseDate = new DateTime(2015,01,15),
        Kilometres = 103917
      },
      new Car
      {
        Id = 2,
        Make = "Dodge",
        Model = "RAM 1500",
        Colour = "Pearl",
        Year = 2020,
        PurchaseDate = new DateTime(2020,05,20),
        Kilometres = 10628
      },
      new Car
      {
        Id = 3,
        Make = "Lambourghini",
        Model = "Gallardo",
        Colour = "Yellow",
        Year = 2019,
        PurchaseDate = new DateTime(2017,02,11),
        Kilometres = 1534
      },
         new Car
      {
        Id = 4,
        Make = "Ferrari",
        Model = "LaFerrari",
        Colour = "Ferrari Red",
        Year = 2018,
        PurchaseDate = new DateTime(2020,11,07),
        Kilometres = 87
      },
             new Car
      {
        Id = 5,
        Make = "Chevrolet",
        Model = "Corevette",
        Colour = "Goodwood Green",
        Year = 1967,
        PurchaseDate = new DateTime(2003,05,16),
        Kilometres = 77482
      }
    };

    public void CreateCar(Car car)
    {
      var maxId = 0;
      if (cars.Count != 0)
      {
        maxId = cars.Max(c => c.Id);
      }
      car.Id = maxId + 1;
      cars.Add(car);
    }

    public void DeleteCar(int id)
    {
      var index = cars.FindIndex(c => c.Id == id);
      cars.RemoveAt(index);
    }

    public void EditCar(Car car)
    {
      var index = cars.FindIndex(c => c.Id == car.Id);
      cars[index] = car;
    }

    public Car GetCar(int id)
    {
      return (cars.Find(c => c.Id == id));
    }

    public IEnumerable<Car> GetCars()
    {
      return cars;
    }
  }
}
