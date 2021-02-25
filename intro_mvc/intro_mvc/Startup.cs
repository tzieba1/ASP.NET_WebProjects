using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace intro_mvc
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      //services.AddMvc((options) => { options.EnableEndpointRouting = false; });   //Required if calling .UseMvc() in .Configure() below.
      services.AddControllersWithViews(); //Required if calling .MapControllerRoute() in .Configure() below to map controller routes to Endpoints.
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseExceptionHandler("/error.html"); //Serve this as the exception handler page.

      //Check the project environment (project Debug properties) if in Development mode to serve Microsoft's default dev exception page with advanced diagnostics.
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      
      app.Use(async (context, next) =>
      {
        if (context.Request.Path.Value.Contains("invalid"))
        {
          throw new Exception("ERROR!");
        }
        await next();
      });


      //WARNING: MUST CLEAR CACHE IN CHROME TO SEE A DIFFERENCE IN ENDPOINTS BY INTERCHANING THE ORDER OF THE NEXT TWO STATEMENTS.
      app.UseRouting();   //MUST GET CALLED BEFORE .UseFileServer() for using default enpoints to mapped controller routes.
      app.UseFileServer();  //For serving static pages via file-system server (using path) from the wwwroot folder of the project.         

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}");
      });


      ////Runs the middleware after performing logic without passing to another piece of middlewware.
      //app.Run(async (context) =>
      //{
      //  await context.Response.WriteAsync("New middleware. ");
      //});

      //Performs logic and passes to another piece of middleware.
      //app.Use(async (context, next) =>
      //{
      //  //Demonstrates that one can conditionally affect the webApp by appending to the application's path (Request.Path.Value)
      //  if (context.Request.Path.Value.StartsWith("/hi"))
      //  {
      //    await context.Response.WriteAsync("New middleware. ");
      //  }
      //  await next();

      //  //Runs this response in case not entering condition above to reach endpoint.
      //  app.Run(async (context) =>
      //  {
      //    await context.Response.WriteAsync("Hello World!");
      //  });
      //});

    }
  }
}
