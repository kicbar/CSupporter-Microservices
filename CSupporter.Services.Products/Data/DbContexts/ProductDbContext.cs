using CSupporter.Services.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace CSupporter.Services.Products.Data.DbContexts
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Product> WarehouseAmounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                        .HasOne(product => product.WarehouseAmounts)
                        .WithOne(warehouseAmounts => warehouseAmounts.Product);
        }
    }
}
