using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using LastSpikeApi.Data;
using LastSpikeApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace LastSpikeApi
{
  public class Startup
  {
    public Startup (IConfiguration configuration)
    {
      Configuration = configuration;

    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices (IServiceCollection services)
    {

#if DEBUG
      services.AddDbContext<LastSpikeContext> (options =>
        options.UseMySql (Configuration.GetConnectionString ("DevConnection")));
#else
      services.AddDbContext<LastSpikeContext> (options =>
        options.UseMySql (Configuration.GetConnectionString ("DefaultConnection")));
#endif
      services.AddControllers ();
    }

    public void Configure (IApplicationBuilder app, IWebHostEnvironment env, LastSpikeContext context)
    {
      if (env.IsDevelopment ())
      {
        app.UseDeveloperExceptionPage ();
      }

      app.UseHttpsRedirection ();

      app.UseRouting ();

      app.UseAuthorization ();

      app.UseEndpoints (endpoints =>
      {
        endpoints.MapControllers ();
      });

      DbInitialize load = new DbInitialize (context);

    }

  }

}