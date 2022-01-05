using CarRental.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Database.EntityConfigurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(p => p.PlateNumber)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(p => p.Brand)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(p => p.Model)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.PricePer24h)
                .HasColumnType("decimal")
                .HasPrecision(15, 2)
                .IsRequired();

            builder.Property(p => p.IsRented)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}
