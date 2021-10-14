using System.Data;
using Autofac;
using Luna.Commons.Communication.Config;
using Luna.Commons.Communication.Interfaces;
using Luna.Commons.Communication.Services;
using Luna.Commons.Models;
using Luna.Commons.Models.Identity;
using Luna.Commons.Repositories;
using Luna.Commons.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;

namespace Luna
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ILifetimeScope Scope { get; set; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            PopulateServices(services);
        }
        
        private void PopulateServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddSingleton<IDbConnection>(_ => new MySqlConnection(connectionString));
            
            services.AddDbContext<LunaDbContext>((options, bld) =>
            {
                bld
                    .UseMySql(connectionString)
                    .EnableDetailedErrors();
            });

            services
                .AddIdentity<LunaIdentityUser, LunaIdentityRole>()
                .AddEntityFrameworkStores<LunaDbContext>()
                .AddDefaultTokenProviders()
                .AddUserManager<LunaUserManager>();

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            
            // Repositories
            services.AddRepositories();

            // Services
            services.AddScoped<CurrentUserAccessor>();

            services.AddScoped<LunaUrlBuilder>();
            
            services.AddSingleton(Configuration.GetSection("MailSettings").Get<MailSettings>());
            services.AddScoped<IMailService, MailService>();
            
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areaDefault",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                
                endpoints.MapRazorPages();
            });
        }
    }
}