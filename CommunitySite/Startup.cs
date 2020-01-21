using System.Runtime.InteropServices;
using CommunitySite.Repositories;
using CommunitySite.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace CommunitySite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private IHostingEnvironment environment;
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            environment = env;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>()
                       .AddDefaultTokenProviders();

            // Inject our repositories into our controllers
            services.AddTransient<ITopicRepo, TopicRepo>();
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<ICommentRepo, CommentRepo>();

            // Configure EF for Windows with SQL Server
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                Configuration["ConnectionStrings:LocalDbConnection"]));//change for publishing
            /*   // For Mac OS with SQLite
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlite(
                    Configuration["ConnectionStrings:SQLiteConnection"]));

                // For Linux with MariaDB
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseMySql(
                    Configuration.GetConnectionString("ConnectionStrings:MySqlConnection")));
            */

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AppDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            context.Database.Migrate();
            SeedData.Seed(context);
            app.UseAuthentication();
        }
    }
}
