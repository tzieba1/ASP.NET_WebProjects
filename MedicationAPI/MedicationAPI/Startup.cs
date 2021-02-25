using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicationAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MedicationAPI
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
      services.AddControllers();

      // 1. INJECT THE DATABASE TO USE THE CONNECTIONSTRING IN appSettings.
      services.AddDbContext<chdbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CHDB")));

      // 2. Inject the Swagger service (Swashbuckle implementation for ASPCore)
      services.AddSwaggerGen();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // Must indicate to Use Swagger and apply lambda expression for setting the endpoint for routing with a name.
      app.UseSwagger();
      app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "MedicationAPI Version 1"));

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
