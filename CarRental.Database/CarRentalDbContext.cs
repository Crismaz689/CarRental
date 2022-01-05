using CarRental.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CarRental.Database
{
    public class CarRentalDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<RentedCar> RentedCars { get; set; }
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
