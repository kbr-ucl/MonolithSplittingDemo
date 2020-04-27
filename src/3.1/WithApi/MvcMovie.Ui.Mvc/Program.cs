using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MvcMovie.Ui.Mvc.UserManagementDatabase;

namespace MvcMovie.Ui.Mvc
{
    public class Program
    {
        // https://docs.microsoft.com/en-us/aspnet/core/security/authorization/secure-data?view=aspnetcore-3.1
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            SeedAsync(host).GetAwaiter().GetResult();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }

        public static async Task SeedAsync(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<UserManagementDbContext>();
                    context.Database.Migrate();

                    var configuration = services.GetRequiredService<IConfiguration>();
                    await SeedUsers.InitializeAsync(services, configuration).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
        }
    }
}