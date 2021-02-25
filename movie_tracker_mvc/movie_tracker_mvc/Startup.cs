using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using movie_tracker_mvc.Models;

namespace movie_tracker_mvc
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllersWithViews();

      //DEPENDENCY INJECTION
      //Add our own movieRepository as a service
      //Specify the type of the service contract (interface)
      //Specify the type of implementation of the service (class)
      //services.AddScoped<IMovieRepository, MovieRepository>();

      //ENTITY FRAMEWORK SQLSERVER
      services.AddDbContext<IMovieRepository, MovieDataContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("MovieDataContext")));

      ////ENTITY FRAMEWORK SQLITE
      //services.AddDbContext<IMovieRepository, MovieDataContext>(options =>
      //  options.UseSqlite(Configuration.GetConnectionString("MovieDataContextLite")));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
