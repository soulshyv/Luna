using System;
using System.Data;
using System.IO;
using Autofac;
using ERDF_DispoReseau.Commons.Csp;
using Luna.Commons.Authentication;
using Luna.Commons.Communication.Config;
using Luna.Commons.Communication.Interfaces;
using Luna.Commons.Communication.Services;
using Luna.Commons.Models;
using Luna.Commons.Models.Identity;
using Luna.Commons.Repositories;
using Luna.Commons.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
                .AddUserManager<LunaUserManager>()
                .AddRoleManager<LunaRoleManager>()
                .AddSignInManager<LunaSignInManager>()
                .AddClaimsPrincipalFactory<LunaClaimsPrincipalFactory>();
            
            // Authentication
            services.AddScoped<SignInManager<LunaIdentityUser>, LunaSignInManager>();
            
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });
           
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = ".Luna.Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.LoginPath = CookieAuthenticationDefaults.LoginPath;
                options.AccessDeniedPath = CookieAuthenticationDefaults.LoginPath;
                options.SlidingExpiration = true;
            });
            
            services.AddAntiforgery(options =>
            {
                options.Cookie.Name = ".Antiforegery";
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Strict;
            });

            // Repositories
            services.AddRepositories();

            // Services
            services.AddScoped<CurrentUserAccessor>();

            services.AddScoped<LunaUrlBuilder>();
            
            services.AddSingleton(Configuration.GetSection("MailSettings").Get<MailSettings>());
            services.AddScoped<IMailService, MailService>();
            
            services.AddHsts(options =>
            {
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(365);
            });
            
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
            
            app.Use(async (context, next) =>
            {
                // En cas de détection d'attaque XSS par le navigateur, bloquer le rendu de la page
                if (!context.Response.Headers.ContainsKey("X-XSS-Protection"))
                {
                    context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
                }
                    
                // Se baser sur le content-type et ne pas essayer de le "deviner"
                if (!context.Response.Headers.ContainsKey("X-Content-Type-Options"))
                {
                    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                }
                    
                // Lorsque le site redirige vers un site externe, ne mettre que le domaine dans le referrer
                if (!context.Response.Headers.ContainsKey("Referrer-Policy"))
                {
                    context.Response.Headers.Add("Referrer-Policy", "origin-when-cross-origin");
                }
                    
                // Empêcher l'ouverture du site dans une iframe
                if (!context.Response.Headers.ContainsKey("X-Frame-Options"))
                {
                    context.Response.Headers.Add("X-Frame-Options", "DENY");
                }

                if (context.Request.Path.StartsWithSegments("/robots.txt"))
                {
                    var robotsTxtPath = Path.Combine(env.ContentRootPath, "robots.txt");
                    var output = "User-agent: *  \nDisallow: /";
                    
                    if (File.Exists(robotsTxtPath))
                    {
                        output = await File.ReadAllTextAsync(robotsTxtPath);
                    }
                    
                    context.Response.ContentType = "text/plain";
                    
                    await context.Response.WriteAsync(output);
                }
                else
                {
                    await next();
                }
            });

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
            
            app.UseCsp(builder =>
            {
                builder.Defaults
                    .AllowSelf();

                builder.Scripts
                    .AllowSelf();

                builder.Styles
                    .AllowSelf();

                builder.Fonts
                    .AllowSelf();

                builder.Images
                    .AllowSelf();
            });
        }
    }
}