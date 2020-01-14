using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CommunitySite.Repositories;
using CommunitySite.Models;

namespace CommunitySite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            using (var ctx = new AppDbContext())
            {
                var stud = new Topic() { Title = "Test" };

                ctx.Topics.Add(stud);
                ctx.SaveChanges();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSetting("detailedErrors", "true")
                .CaptureStartupErrors(true)
                .UseDefaultServiceProvider(options =>
                      options.ValidateScopes = false);
    }
}
