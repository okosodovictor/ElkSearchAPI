using Microsoft.EntityFrameworkCore;
using SmartELK.Domain.Entities;
using SmartELK.Infrastructure.Configurations;

namespace SmartELK.Infrastructure.Database;

public class ProductsContext : DbContext
{
    public ProductsContext(DbContextOptions<ProductsContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(p => p.Description)
                .HasColumnType("text");

            entity.Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            
            entity.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(c => c.CategoryId);

            entity.Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(c => c.Description)
                .HasColumnType("text");
        });

        //Seed Category Data
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        //Seed 100 Product Data
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }
}