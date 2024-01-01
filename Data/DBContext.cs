using Microsoft.EntityFrameworkCore;
using Raythos_Aerospace.Models.entities;


namespace Raythos_Aerospace.Data
{
    public class RaythosContext : DbContext
    {
        public RaythosContext(DbContextOptions<RaythosContext> options)
        : base(options)
        { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AircraftEntity> Aircrafts { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ShippingEntity> Shippings { get; set; }

        // Add any additional DbSet properties as needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships between entities (if any)
            modelBuilder.Entity<OrderEntity>()
                .HasOne(o => o.Customer)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderEntity>()
                .HasOne(o => o.AircraftModel)
                .WithMany()
                .HasForeignKey(o => o.AircraftModelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ShippingEntity>()
                .HasOne(s => s.Order)
                .WithMany()
                .HasForeignKey(s => s.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            // Add any additional configurations as needed
        }

    }
}
