using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportingService.Persistence.Entities;

namespace ReportingService.Persistence.Configuration;

internal static class CustomerEntityConfiguration
{
    internal static void ConfigureCustomer(this ModelBuilder builder)
    {
        builder.Entity<Customer>().HasKey(p => p.Id);

        builder.Entity<Customer>().Property(p => p.Id)
        .IsRequired()
        .ValueGeneratedOnAdd();

        builder.Entity<Customer>().HasMany(x => x.Accounts)
                .WithOne(y => y.Customer)
                .HasForeignKey(x => x.CustomerId);

        builder.Entity<Customer>().HasMany(x => x.Transactions).WithOne(y=>y.Customer)
            .HasForeignKey(y => y.CustomerId).HasPrincipalKey(x => x.CustomerServiceId);

        builder.Entity<Customer>().Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Entity<Customer>().Property(x => x.FirstName)
        .IsRequired()
        .HasMaxLength(30);

        builder.Entity<Customer>().Property(x => x.LastName)
        .IsRequired()
        .HasMaxLength(30);

        builder.Entity<Customer>().Property(p => p.Email)
        .IsRequired()
        .HasMaxLength(50);

        builder.Entity<Customer>().Property(x => x.Password)
        .IsRequired()
        .HasMaxLength(150);

        builder.Entity<Customer>().Property(x => x.Role)
        .IsRequired();

        builder.Entity<Customer>().Property(p => p.CustomVipDueDate)
       .IsRequired(false)
       .HasColumnType("timestamp without time zone");

        builder.Entity<Customer>().Property(p => p.IsDeactivated)
        .IsRequired()
        .HasDefaultValue(false);

        builder.Entity<Customer>().Property<DateTime>(x => x.BirthDate);
    }
}
