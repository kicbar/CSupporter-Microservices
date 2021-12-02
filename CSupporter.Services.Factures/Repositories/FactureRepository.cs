using CSupporter.Services.Factures.Data.DbContexts;
using CSupporter.Services.Factures.Models;
using CSupporter.Services.Factures.Repositories.IRepositories;
using System;
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

        public Facture GetFactureById(int factureId)
        {
            return _factureDbContext.Factures.Where(f => f.FactureId == factureId).FirstOrDefault();
        }

        public Facture CreateUpdateFacture(Facture facture)
        {
            Facture factureExist = _factureDbContext.Factures.Where(f => f.FactureId == facture.FactureId).FirstOrDefault();
            if (factureExist != null)
            {
                facture.UpdateDate = DateTime.Now;
                _factureDbContext.Update(facture);
            }
            else
            {
                facture.FactureId = 0;
                _factureDbContext.Add(facture);
            }
            _factureDbContext.SaveChanges();

            return facture;
        }

        public bool DeleteFacture(int factureId)
        {
            Facture factureExist = _factureDbContext.Factures.Where(f => f.FactureId == factureId).FirstOrDefault();

            if (factureExist != null)
            {
                _factureDbContext.Factures.Remove(factureExist);
                _factureDbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public void CalculateFacturesValue()
        { 
            List<Facture> factures = _factureDbContext.Factures.ToList();
            foreach (Facture facture in factures)
            {
                CalculateFactureValue(facture.FactureId);
            }
        }

        private void CalculateFactureValue(int factureId)
        {
            double factureValue = 0;
            List<Position> positions = _factureDbContext.Positions.Where(position => position.FactureId == factureId).ToList();

            foreach (Position position in positions)
            {
                factureValue += position.ProductPrice * position.ProductAmount;
            }

            Facture facture = _factureDbContext.Factures.Where(facture => facture.FactureId == factureId).FirstOrDefault();
            facture.Value = factureValue;
            _factureDbContext.SaveChanges();
        }
    }
}
