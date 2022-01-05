using CarRental.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Database.EntityConfigurations
{
    public class RentedCarConfiguration : IEntityTypeConfiguration<RentedCar>
    {
        public void Configure(EntityTypeBuilder<RentedCar> builder)
        {
            builder.HasOne(c => c.Car)
                .WithMany(cu => cu.RentedCars)
                .HasForeignKey(c => c.CarId);

            builder.HasOne(u => u.User)
                .WithMany(cu => cu.RentedCars)
                .HasForeignKey(u => u.UserId);
        }
    }
}
