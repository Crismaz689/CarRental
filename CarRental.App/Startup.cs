using CarRental.App.Repositories;
using CarRental.Database;
using CarRental.Database.Seeders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CarRental.App
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCarRentalDbContext(_config);
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IRentRepository, RentRepository>();
            services.AddControllersWithViews();

            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(1);  
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Car}/{action=Index}/{id?}");
            });

            CarRentalDbSeeder.Seed(app);
        }
    }
}
