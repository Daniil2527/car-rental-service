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

        
        base.OnModelCreating(modelBuilder);
        
        var userBuilder = modelBuilder.Entity<User>();

        userBuilder.HasKey(u => u.Id);
        userBuilder.Property(u => u.Id)
            .IsRequired()
            .ValueGeneratedNever(); 

        userBuilder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        userBuilder.Property(u => u.FullName)
            .IsRequired()
            .HasMaxLength(100);

        userBuilder.Property(u => u.PhoneNumber)
            .HasMaxLength(20);

        userBuilder.HasIndex(u => u.Email)
            .IsUnique();
        
        var carBuilder = modelBuilder.Entity<Car>();

        carBuilder.HasKey(c => c.Id);
        carBuilder.Property(c => c.Id)
            .IsRequired()
            .ValueGeneratedNever();

        carBuilder.Property(c => c.Brand)
            .IsRequired()
            .HasMaxLength(50);
        carBuilder.Property(c => c.Color)
            .HasMaxLength(30);

        carBuilder.Property(c => c.Model)
            .IsRequired()
            .HasMaxLength(50);

        carBuilder.Property(c => c.Description)
            .HasMaxLength(500);

        carBuilder.Property(c => c.Price)
            .HasPrecision(10, 2); 
        
        var orderBuilder = modelBuilder.Entity<Order>();

        orderBuilder.HasKey(o => o.Id);
        orderBuilder.Property(o => o.Id)
            .IsRequired()
            .ValueGeneratedNever();

        orderBuilder.Property(o => o.OrderDate)
            .IsRequired();

        orderBuilder.Property(o => o.Type)
            .IsRequired();
        

        userBuilder.HasMany(u => u.Cars)
            .WithOne(c => c.Owner)
            .HasForeignKey(c => c.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);

        userBuilder.HasMany(u => u.Orders)
            .WithOne(o => o.Buyer)
            .HasForeignKey(o => o.BuyerId)
            .OnDelete(DeleteBehavior.Cascade);

        carBuilder.HasMany(c => c.Orders)
            .WithOne(o => o.Car)
            .HasForeignKey(o => o.CarId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}
