using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ODoctor.Infrastructure.Data;
using ODoctor.Infrastructure.Identity;

namespace ODoctor.UI.Razor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args)
                .Build();
            
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerfactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var oDoctorDbContext = services.GetRequiredService<ODoctorDbContext>();
                    ODoctorDbContextSeed.SeedAsync(oDoctorDbContext, loggerfactory)
                        .Wait();

                    var userManager = services.GetRequiredService<UserManager<ODoctorUser>>();
                    ODoctorIdentityDbContextSeed.SeedAsync(userManager)
                        .Wait();
                }
                catch(Exception ex)
                {
                    var logger = loggerfactory.CreateLogger<Program>();
                    logger.LogError(ex, "Error occured while seeding Db");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
