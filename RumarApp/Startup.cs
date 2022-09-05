using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Autofac;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using DatabaseMigrations.Data;

namespace RumarApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddNotyf(config => 
            { 
                config.DurationInSeconds = 10; 
                config.IsDismissable = true; 
                config.Position = NotyfPosition.BottomRight; 
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                     .AddCookie(options =>
                     {
                         options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                         options.LoginPath = "/Security/Login";
                         options.ReturnUrlParameter = "/Home/Index";
                         options.AccessDeniedPath = "/Security/AccessDenied";
                         options.SlidingExpiration = true;
                     });

            services.AddDistributedMemoryCache();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             );

            services.AddRazorPages().AddRazorPagesOptions(options=>
            {
                options.Conventions.AuthorizeFolder("/Loans");
                options.Conventions.AuthorizeFolder("/Client");
            });

            services.AddHttpContextAccessor();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ServiceModule());
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

            app.UseNotyf();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            };

            app.UseCookiePolicy(cookiePolicyOptions);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Security}/{action=Login}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    } 
}
