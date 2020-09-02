using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ODoctor.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System;
using ODoctor.Infrastructure.Data;
using ODoctor.Core.Interfaces;
using ODoctor.UI.Razor.Interfaces;
using ODoctor.UI.Razor.Services;
using ODoctor.Core.Services;

namespace ODoctor.UI.Razor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private static void ConfigureCookieSettings(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Signout";
                options.Cookie = new CookieBuilder
                {
                    IsEssential = true // required for auth to work without explicit user consent; adjust to suit your privacy policy
                };
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<ODoctorUser, IdentityRole>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<ODoctorIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<ODoctorDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ODoctorDbConnection")));

            services.AddDbContext<ODoctorIdentityDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("ODoctorDbIdentityConnection"));
            });
            ConfigureCookieSettings(services);

            services.AddScoped(typeof(IAsynRepository<>), typeof(Repository<>));
            services.AddScoped<Interfaces.IDoctorSearchService, DoctorSearchService>();
            services.AddScoped<ICalendarService, CalendarService>();

            services.AddRazorPages()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/Appointment");
                    options.Conventions.AuthorizeFolder("/Calendar");
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
