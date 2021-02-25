using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment2.Models
{
  public interface ICarRepository
  {
    IEnumerable<Car> GetCars();
    Car GetCar(int id);
    void CreateCar(Car car);
    void EditCar(Car car);
    void DeleteCar(int id);
  }
}
