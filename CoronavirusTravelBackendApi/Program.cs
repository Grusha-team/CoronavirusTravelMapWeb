using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoronavirusTravelBackendApi
{
    public class Program
    {
        
        public static void Main()
        { 
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables().Build();
            CreateHostBuilder(config, new Hub()).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(IConfigurationRoot config, Hub hub) =>
            Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(web =>
            {
                web.UseConfiguration(config);
                web.UseContentRoot(Directory.GetCurrentDirectory());
                web.UseIISIntegration();
                web.ConfigureLogging(l =>
                {
                    l.AddConfiguration(config.GetSection("Logging"));
                    l.AddConsole();
                });
                web.ConfigureServices(s => s.AddRouting());
                web.Configure(app =>
                            app.UseRouter(r =>
                            {
                                r.MapGet("GetCountryData", async (request, response, routeData) =>
                                {
                                    var temp = request.Query["name"];
                                    var data = JsonConvert.SerializeObject(hub.AssociateCountry(temp));
                                    await response.WriteAsync(data);
                                });
                                r.MapGet("GetRoute", async (request, response, routeData) =>
                                {
                                    var start = request.Query["start"];
                                    var finish = request.Query["finish"];
                                    var data = hub.FindRoute(start, finish);
                                    await response.WriteAsync(data == null ? "null" : data);
                                });

                            })
                            );
            });
    }
}
