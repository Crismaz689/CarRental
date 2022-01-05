using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Database
{
    public static class CarRentalDbContextExtension
    {
        public static IServiceCollection AddCarRentalDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<CarRentalDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("Develop")));

            return services;
        }
    }
}
