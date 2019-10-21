using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastSpikeApi.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LastSpikeApi
{
    public class Program
    {
        public static void Main (string[] args)
        {

            Seed seedInstance = new Seed();
            seedInstance.Initialize();

            var host = CreateHostBuilder (args).Build ();

            // using (var scope = host.Services.CreateScope ())
            // {
            //     var services = scope.ServiceProvider;

            //     try
            //     {
            //         Seed seedInstance = new Seed ();
            //         seedInstance.Initialize (services);
            //     }
            //     catch (Exception ex)
            //     {
            //         var logger = services.GetRequiredService<ILogger<Program>> ();
            //         logger.LogError (ex, "An error occurred seeding the DB.");
            //     }
            // }

            host.Run ();
        }

        public static IHostBuilder CreateHostBuilder (string[] args) =>
            Host.CreateDefaultBuilder (args)
            .ConfigureWebHostDefaults (webBuilder =>
            {
                webBuilder.UseStartup<Startup> ();
            });
    }
}