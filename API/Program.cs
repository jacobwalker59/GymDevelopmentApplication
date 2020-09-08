using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.IdentityFolder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<DataBaseContext>();
            await context.Database.MigrateAsync();
            // ------ this wouldnt work either because its the database context
            // var userManager = services.GetRequiredService<UserManager<AppUser>>();
            // var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
            // await AppIdentityDBContextSeed.SeedAll(userManager,roleManager);
            
            // await AppIdentityDBContextSeed.SeedUserData(userManager);
            //  DatabaseInitializer.InitializeDatabaseSeed(context);
             var userManager = services.GetRequiredService<UserManager<AppUser>>();
             var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
             var identityContext = services.GetRequiredService<AppIdentityDBContext>();
            await identityContext.Database.MigrateAsync();
            await AppIdentityDBContextSeed.SeedUserData(userManager);
            await AppIdentityDBContextSeed.SeedRoles(roleManager);

            // inlcude role manager here and go for it
       
           // JsonDBInitializer.SeedDbWithJsonData(context);
        
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while seeding the database.");
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
