using CSupporter.Services.Factures.Data.DbContexts;
using CSupporter.Services.Factures.Models;
using CSupporter.Services.Factures.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace CSupporter.Services.Factures.Repositories
{
    public class FactureRepository : IFactureRepository
    {
        private readonly FactureDbContext _factureDbContext;

        public FactureRepository(FactureDbContext factureDbContext)
        {
            _factureDbContext = factureDbContext;
        }

        public List<Facture> GetAllFactures()
        {
            return _factureDbContext.Factures.ToList();
        }

        

    }
}
