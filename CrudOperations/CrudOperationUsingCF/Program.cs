using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudOperationUsingCF.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CrudOperationUsingCF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            SetUpDbContext(host);
            host.Run();
        }
        static void SetUpDbContext(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SampleCoreDbContext>();
                    //Context
                    context.Database.EnsureCreated();
                    //context.Database.Migrate();
                    Seed(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }

        }


        static void Seed(SampleCoreDbContext context)
        {
            if (!context.Department.Any())
            {
                context.Department.AddRange(new List<Department>()
                {
                    new Department()
                    {
                         DepartmentName="Test1Dept",
                         IsActive=false
                    },
                     new Department()
                    {
                         DepartmentName="Test12Dept",
                         IsActive=false
                    },
                      new Department()
                    {
                         DepartmentName="Test13Dept",
                         IsActive=false
                    }

                });
                context.SaveChanges();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
