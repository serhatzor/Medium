using Microsoft.EntityFrameworkCore;
using EFCorePerformanceExample.Entities;

namespace EFCorePerformanceExample;

public class ECommerceDbContext : DbContext
{
    public ECommerceDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("ECommerceDb");
    }
    public void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(100);
        modelBuilder.Entity<Product>().Property(p => p.Description).HasMaxLength(500);
        modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");

        modelBuilder.Entity<ProductCategory>().HasKey(p => p.Id);
        modelBuilder.Entity<ProductCategory>().Property(p => p.Name).HasMaxLength(100);
        modelBuilder.Entity<ProductCategory>().Property(p => p.Description).HasMaxLength(500);

        modelBuilder.Entity<Order>().HasKey(o => o.Id);
        modelBuilder.Entity<Order>().Property(o => o.Name).HasMaxLength(100);
        modelBuilder.Entity<Order>().Property(o => o.Description).HasMaxLength(500);
        modelBuilder.Entity<Order>().Property(o => o.TotalPrice).HasColumnType("decimal(18,2)");
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Order> Orders { get; set; }
}

