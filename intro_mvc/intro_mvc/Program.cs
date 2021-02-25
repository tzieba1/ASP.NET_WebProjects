using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace intro_mvc
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var webHostBuilder = CreateHostBuilder(args);
      var webHost = webHostBuilder.Build();
      webHost.Run();
    }

    //public static IHostBuilder CreateHostBuilder(string[] args)
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
      var hostBuilder = Host.CreateDefaultBuilder(args);
      hostBuilder.ConfigureWebHostDefaults(webBuilder =>
      {
        webBuilder.UseStartup<Startup>();
      });
      return hostBuilder;

      //return Host.CreateDefaultBuilder(args)
      //    .ConfigureWebHostDefaults(webBuilder =>
      //    {
      //      webBuilder.UseStartup<Startup>();
      //    });
    }
  }
}