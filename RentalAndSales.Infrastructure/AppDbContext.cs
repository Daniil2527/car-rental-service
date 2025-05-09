using Microsoft.EntityFrameworkCore;
using RentalAndSales.Domain;

namespace RentalAndSales.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
    
    public DbSet<User> Users => Set<User>();
    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Order> Orders => Set<Order>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<User>()
            .HasMany(u => u.Cars)
            .WithOne(c => c.Owner)
            .HasForeignKey(c => c.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.Orders)
            .WithOne(o => o.Buyer)
            .HasForeignKey(o => o.BuyerId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Car>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Car)
            .HasForeignKey(o => o.CarId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}
