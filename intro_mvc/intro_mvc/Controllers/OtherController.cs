using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using intro_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace intro_mvc.Controllers
{
  public class OtherController : Controller
  {
    public IActionResult Index()
    {
      //return new ContentResult { Content = "Hello from OtherController / Index" };

      //ViewBag.Title = "Heading From Controller";
      //ViewBag.Name = "Bobby Brown";
      //ViewBag.Served = DateTime.Now;
      //return View();

      var stuff = new Stuff
      {
        Title = "Heading From Controller",
        Name = "Bobby Brown",
        Served = DateTime.Now
      };
      return View(stuff);
    }

    //public IActionResult Post(int? id)
    [Route("stuff/{year:min(2018)}/{month:range(1,12)}/{key}")]
    //[Route("stuff/{year:int)}/{month:int)}/{key}")]
    public IActionResult Post(int year, int month, string key)
    {
      //if (id == null)
      //{
      //  return new ContentResult { Content = $"Hello from OtherController / Post, id=null"};
      //}
      //else
      //{
        return new ContentResult { Content = $"Hello from OtherController / Post, year={year}, month={month}, key={key}" };
      //}
    }
  }
}