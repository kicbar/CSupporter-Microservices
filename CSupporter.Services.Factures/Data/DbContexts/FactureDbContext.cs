using CSupporter.Services.Factures.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CSupporter.Services.Factures.Data.DbContexts
{
    public class FactureDbContext : DbContext
    {
        public FactureDbContext(DbContextOptions<FactureDbContext> options) : base(options)
        {

        }

        public DbSet<Facture> Factures { get; set; }
        public DbSet<Position> Positions { get; set; }

/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Facture>().HasData(new Facture
            {
                FactureId = 1,
                FactureNo = "FV11/11/2021",
                Value = 200.99,
                ContractorId = 1,
                Positions = new List<Position> 
                {
                    new Position
                    {
                        PositionId = 1,
                        ProductName = "Smartphone Xiaomi",
                        ProductAmount = 1,
                        ProductPrice = 999.99,
                        FactureId = 1
                    },
                    
                    new Position
                    {
                        PositionId = 1,
                        ProductName = "Smartphone IPhone",
                        ProductAmount = 1,
                        ProductPrice = 2999.99,
                        FactureId = 1
                    }
                }
            });

            modelBuilder.Entity<Facture>().HasData(new Facture
            {
                FactureId = 2,
                FactureNo = "FV12/11/2021",
                Value = 99.99,
                ContractorId = 1,
                Positions = new List<Position>
                {
                    new Position
                    {
                        PositionId = 1,
                        ProductName = "Smartphone Samsung",
                        ProductAmount = 1,
                        ProductPrice = 999.99,
                        FactureId = 1
                    },

                    new Position
                    {
                        PositionId = 1,
                        ProductName = "Headphone",
                        ProductAmount = 1,
                        ProductPrice = 100,
                        FactureId = 1
                    }
                }
            });

            modelBuilder.Entity<Facture>().HasData(new Facture
            {
                FactureId = 3,
                FactureNo = "FV13/11/2021",
                Value = 22.99,
                ContractorId = 1,
                Positions = new List<Position>
                {
                    new Position
                    {
                        PositionId = 1,
                        ProductName = "TV Samsung",
                        ProductAmount = 1,
                        ProductPrice = 1200.20,
                        FactureId = 1
                    },

                    new Position
                    {
                        PositionId = 1,
                        ProductName = "Laptop Lenovo",
                        ProductAmount = 1,
                        ProductPrice = 3500,
                        FactureId = 1
                    }
                }
            });
        }*/
    }
}
