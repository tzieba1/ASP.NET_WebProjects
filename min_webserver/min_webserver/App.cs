using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace min_webserver
{
  class App
  {
    static void Main()
    {
      new WebHostBuilder()
        .UseKestrel()
        .Configure(a => a.Run(c => c.Response.WriteAsync("Minimum Web Server")))
        .Build()
        .Run();
    }
  }
}
