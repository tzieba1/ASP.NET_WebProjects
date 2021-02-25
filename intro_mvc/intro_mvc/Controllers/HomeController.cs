using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace intro_mvc.Controllers
{
  /// <summary>
  ///   Default controller scaffolding here extends the Controller class and returns a View as an IActionResult.
  ///   An exception will occur and the developer debugging page is served from Startup.cs
  ///   Startup.cs attempts to find an Index.cshtml file in the Views and Pages folders of fileserver filesystem.
  /// </summary>
  //public class HomeController : Controller
  //{
  //    public IActionResult Index()
  //    {
  //        return View();
  //    }
  //}

  //Returns text to the HomeController to be displayed on the /Home/Index.cshtml page.
  //public class HomeController
  //{
  //    public string Index()
  //    {
  //        return "Home Controller!";
  //    }
  //}

  //Another way to generate a similar outcome as above, except using ContentResult to return an IActionResult.
  public class HomeController : Controller
  {
      public IActionResult Index()
      {
      //return new ContentResult {  Content = "Hello from HomeController / Index"};
      return View();
      }
  }
}