using Microsoft.EntityFrameworkCore;
using Rent2Deliver.Domain;

namespace Rent2Deliver.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Motorcycle> Motorcycles { get; set; }
    public DbSet<DeliveryPerson> DeliveryPersons { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<MotorcycleRegisteredEvent> MotorcycleRegisteredEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Motorcycle>()
            .HasIndex(m => m.LicensePlate)
            .IsUnique();

        modelBuilder.Entity<DeliveryPerson>()
            .HasIndex(dp => dp.Cnpj)
            .IsUnique();

        modelBuilder.Entity<DeliveryPerson>()
            .HasIndex(dp => dp.LicenseNumber)
            .IsUnique();

        // Relacionamento Rental -> Motorcycle
        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Motorcycle)
            .WithMany()
            .HasForeignKey(r => r.MotorcycleId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento Rental -> DeliveryPerson
        modelBuilder.Entity<Rental>()
            .HasOne(r => r.DeliveryPerson)
            .WithMany()
            .HasForeignKey(r => r.DeliveryPersonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}