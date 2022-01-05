using CarRental.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Database.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Username)
                .HasMaxLength(24)
                .IsRequired();

            builder.Property(p => p.PasswordHash)
                .IsRequired();

            builder.Property(p => p.FirstName)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(p => p.Surname)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(p => p.Pesel)
                .HasColumnType("nvarchar(11)")
                .IsRequired();

            builder.Property(p => p.Balance)
                .HasColumnType("decimal")
                .HasPrecision(15, 2)
                .HasDefaultValue(0.00)
                .IsRequired();
        }
    }
}
