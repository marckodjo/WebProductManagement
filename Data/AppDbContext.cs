using Microsoft.EntityFrameworkCore;
using WebProductManagement.Models;

namespace WebProductManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration du modèle Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            });

            // Données de test
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Ordinateur portable", Description = "Ordinateur portable haute performance", Price = 999.99m, Stock = 10 },
                new Product { Id = 2, Name = "Souris sans fil", Description = "Souris ergonomique sans fil", Price = 29.99m, Stock = 50 },
                new Product { Id = 3, Name = "Clavier mécanique", Description = "Clavier mécanique RGB", Price = 89.99m, Stock = 25 }
            );
        }
    }
}