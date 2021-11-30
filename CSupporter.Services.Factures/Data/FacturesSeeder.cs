using CSupporter.Services.Factures.Data.DbContexts;
using CSupporter.Services.Factures.Models;
using System.Collections.Generic;
using System.Linq;

namespace CSupporter.Services.Factures.Data
{
    public class FacturesSeeder
    {
        private readonly FactureDbContext _factureDbContext;

        public FacturesSeeder(FactureDbContext factureDbContext)
        {
            _factureDbContext = factureDbContext;
        }

        public void Seed()
        {
            if (_factureDbContext.Database.CanConnect())
            {
                if (!_factureDbContext.Factures.Any())
                    InsertSampleData();
            }
        }

        private void InsertSampleData()
        {
            var factures = new List<Facture>
            {
                new Facture
                {
                    FactureNo = "FV13/11/2021",
                    FactureType = "INCOME",
                    ContractorId = 1,
                    Positions = new List<Position>
                    {
                        new Position
                        {
                            ProductName = "TV Samsung",
                            ProductAmount = 1,
                            ProductPrice = 1200.20
                        },
                        new Position
                        {
                            ProductName = "Laptop ASUS",
                            ProductAmount = 1,
                            ProductPrice = 3500
                        }
                    }
                },
                new Facture
                {
                    FactureNo = "FV12/11/2021",
                    FactureType = "INCOME",
                    ContractorId = 2,
                    Positions = new List<Position>
                    {
                        new Position
                        {
                            ProductName = "Smartphone Samsung",
                            ProductAmount = 1,
                            ProductPrice = 999.99
                        },
                        new Position
                        {
                            ProductName = "Headphone",
                            ProductAmount = 1,
                            ProductPrice = 100
                        }
                    }
                },
                new Facture
                {
                    FactureNo = "FV22/11/2021",
                    FactureType = "OUTCOME",
                    ContractorId = 2,
                    Positions = new List<Position>
                    {
                        new Position
                        {
                            ProductName = "IPhone 6S",
                            ProductAmount = 1,
                            ProductPrice = 999.99
                        },

                        new Position
                        {
                            ProductName = "Laptop Lenovo",
                            ProductAmount = 1,
                            ProductPrice = 3100
                        }
                    }
                }
            };

            _factureDbContext.AddRange(factures);
            _factureDbContext.SaveChanges();
        }
    }
}
