using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Data;
using System.Security.Principal;
using System.Data.Entity;

namespace WebApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
      var host = CreateHostBuilder(args).Build();

      CreateDbIfNotExists(host);

      host.Run();
    }
    private static void CreateDbIfNotExists(IHost host)
    {
      using (var scope = host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;
        try
        {
          var context = services.GetRequiredService<ApplicationDbContext>();
          DbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {
          var logger = services.GetRequiredService<ILogger<Program>>();
          logger.LogError(ex, "An error occurred creating the DB.");
        }
      }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

  //public static class IdentityExtensions
  //{
  //  public static string GetEmailAdress(this IIdentity identity)
  //  {
  //    var userId = identity.GetUserId();
  //    using (var context = new DbContext())
  //    {
  //      var user = context.Users.FirstOrDefault(u => u.Id == userId);
  //      return user.Email;
  //    }
  //  }
  //}
  }
  
