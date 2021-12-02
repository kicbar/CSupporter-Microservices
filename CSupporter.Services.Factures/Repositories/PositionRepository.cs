using CSupporter.Services.Factures.Data.DbContexts;
using CSupporter.Services.Factures.Models;
using CSupporter.Services.Factures.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSupporter.Services.Factures.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly FactureDbContext _factureDbContext;

        public PositionRepository(FactureDbContext factureDbContext)
        {
            _factureDbContext = factureDbContext;
        }

        public List<Position> GetAllPositionsForFacture(int factureId)
        {
            CalculateFactureValue(factureId);
            return _factureDbContext.Positions.Where(position => position.FactureId == factureId).ToList();
        }

        public Position AddPositionToFacture(Position position)
        {
            _factureDbContext.Add(position);
            CalculateFactureValue(position.FactureId);
            _factureDbContext.SaveChanges();
            return position;
        }

        public bool RemovePositionFromFacture(int positionId)
        {
            try
            {
                Position position = _factureDbContext.Positions.Where(position => position.PositionId == positionId).FirstOrDefault();

                if (position != null)
                {
                    _factureDbContext.Remove(position);
                    CalculateFactureValue(position.FactureId);
                    _factureDbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
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
