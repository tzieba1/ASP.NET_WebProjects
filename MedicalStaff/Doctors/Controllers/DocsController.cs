using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Doctors.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doctors.Controllers
{
  public class DocsController : Controller
  {

    // While developing, must copy the specific port assigned to this solutions WebAPI project to test the WebAPI
    private string baseURL = "http://localhost:49533/api/";


    // GET: Docs
    public async Task<IActionResult> Index()
    {
      var docs = new List<Doc>();

      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri(baseURL);
        var response = await client.GetAsync("physicians");
        if (response.IsSuccessStatusCode)
        {
          var json = await response.Content.ReadAsStringAsync();
          docs = JsonSerializer.Deserialize<List<Doc>>(json);
        }
      }


      return View(docs);
    }

    // GET: Docs/Details/5
    public async Task<IActionResult> Details(int id)
    {
      
      var doc = await GetDocAsync(id);

      return View(doc);
    }

    // GET: Docs/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Docs/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Doc doc)
    {
      try
      {
        if (ModelState.IsValid)
        {
          var content = new StringContent(JsonSerializer.Serialize(doc), Encoding.UTF8, "application/json");

          using (var client = new HttpClient())
          {
            client.BaseAddress = new Uri(baseURL);
            var response = await client.PostAsync("physicians", content);
          }
        }
        return RedirectToAction(nameof(Index));
      }
      catch (Exception)
      {
        return View();
      }
    }

    // GET: Docs/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
      var doc = await GetDocAsync(id);

      return View(doc);
    }

    // POST: Docs/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Doc doc)
    {
      try
      {
        if(ModelState.IsValid)
        {
          doc.physicianId = id;
          var content = new StringContent(JsonSerializer.Serialize(doc), Encoding.UTF8, "application/json");

          using (var client = new HttpClient())
          {
            client.BaseAddress = new Uri(baseURL);
            var response = await client.PutAsync($"physicians/{id}", content);
          }
        }

        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: Docs/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
      var doc = await GetDocAsync(id);

      return View(doc);
    }

    // POST: Docs/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, IFormCollection collection)
    {
      try
      {
        using(var client = new HttpClient())
        {
          client.BaseAddress = new Uri(baseURL);
          var response = await client.DeleteAsync($"physicians/{id}");
        }

        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    private async Task<Doc> GetDocAsync(int id)
    {
      var doc = new Doc();

      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri(baseURL);
        var response = await client.GetAsync($"physicians/{id}");
        if (response.IsSuccessStatusCode)
        {
          var json = await response.Content.ReadAsStringAsync();
          doc = JsonSerializer.Deserialize<Doc>(json);
        }
      }
      return doc;
    }
  }
}