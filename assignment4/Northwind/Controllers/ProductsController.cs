using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Northwind.Models;

namespace Northwind.Controllers
{

  [Authorize]
  public class ProductsController : Controller
  {
    // GET: Products
    [AllowAnonymous]
    public async Task<ActionResult> Index(int categoryId = 1)
    {
      // Asycnchronously retrieve the list of all Categories modelled by the Category class (built 
      //  using JSON schema from NorthwindAPI) to create its drop-down repsresentation from ViewData.
      List<Category> rawCategories = await GetCategoriesAsync();
      var categories = from c in rawCategories select new SelectListItem() { Text = c.categoryName, Value = c.categoryId.ToString() };
      ViewData["categoryList"] = new SelectList(categories, "Value", "Text");

      // Return all products from the specified category by calling NorthwindAPI asynchronously
      List<Product> products = new List<Product>();

      // To call NorthwindAPI, should use an HttpClient in separate scope.
      using (var client = new HttpClient())
      {
        // Prepare http headers.
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // Call for a response from the client to return requested products by selected Category id passed in.
        var response = await client.GetAsync($"https://localhost:44380/api/Products/ByCategory/{categoryId}");
        if (response.IsSuccessStatusCode)
        {
          var json = await response.Content.ReadAsStringAsync();
          products = JsonSerializer.Deserialize<List<Product>>(json);
        }
      }

      return View(products);
    }

    // GET: Products/Details/5
    public async Task<IActionResult> Details(int id)
    {
      // Return the product selected from the Index view with the specified id.
      Product product;
      using (var client = new HttpClient())
      {
        // Prepare http headers.
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // Call for a response from the client to return requested product by selected Product id from Details routing.
        var response = await client.GetAsync($"https://localhost:44380/api/Products/{id}");

        // Check that the response has a success status code, but this includes 204 - "No Content". So, must check for that as well 
        //    because the NorthwindAPI returns either a Product or null from /api/Products/{id}
        if (response.IsSuccessStatusCode && !response.StatusCode.Equals(System.Net.HttpStatusCode.NoContent))
        {
          var json = await response.Content.ReadAsStringAsync();
          product = JsonSerializer.Deserialize<Product>(json);

          // Get all category names asynchronously and search them to return the 
          //    category name being used in the View for the product found by id
          List<Category> categories = await GetCategoriesAsync();
          Category category = categories.Find(c => c.categoryId == product.categoryId);
          ViewData["categoryName"] = category.categoryName;

          return View(product);
        } 
        else
        {
          return View("Error", new ErrorViewModel { RequestId = id.ToString() });
        }
      }
    }

    /// <summary>
    ///   Retrieve categories from NorthwindAPI as an asynchronous Task of type List<Category> to be returned upon await.
    /// </summary>
    /// <returns>Asynchronous Task containing a List of every category from Northwind API.</returns>
    public async Task<List<Category>> GetCategoriesAsync()
    {
      var categories = new List<Category>();

      // Must encapsulate the client instance within its own "using" scope of an HttpClient object.
      using (var client = new HttpClient())
      {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // First await and return all categories in the form of an asynchronous response from an inpersonated
        //  client via URL routing to /api/Categories - i.e. redirects to queried JSON data from NorthwindAPI. 
        var response = await client.GetAsync("https://localhost:44380/api/Categories");

        if (response.IsSuccessStatusCode)
        {
          var json = await response.Content.ReadAsStringAsync();
          categories = JsonSerializer.Deserialize<List<Category>>(json);
        }
      }

      return categories;
    }
  }
}