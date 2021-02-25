using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecureSite.Models;

namespace SecureSite.Controllers
{
  [Authorize]
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
      return View();
    }
    
    // NOT THE SAME AS [Authorize(Roles = "Admin, Manager")]
    // Comma delimited roles in a single annotation uses "OR" and separate [Authorize()] annotations uses "AND" for Role Authoization.
    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "Manager")]
    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
