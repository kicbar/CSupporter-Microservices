using CSupporter.Services.Factures.Models;
using Microsoft.EntityFrameworkCore;

namespace CSupporter.Services.Factures.Data.DbContexts
{
    public class FactureDbContext : DbContext
    {
        public FactureDbContext(DbContextOptions<FactureDbContext> options) : base(options)
        {

        }

        public DbSet<Facture> Factures { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facture>()
                        .HasMany(facture => facture.Positions)
                        .WithOne(position => position.Facture);
        }
    }
}
