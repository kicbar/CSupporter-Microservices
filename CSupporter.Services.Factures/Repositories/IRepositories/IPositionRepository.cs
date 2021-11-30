using CSupporter.Services.Factures.Models;
using System.Collections.Generic;

namespace CSupporter.Services.Factures.Repositories.IRepositories
{
    public interface IPositionRepository
    {
        List<Position> GetAllPositionsForFacture(int factureId);
        Position AddPositionToFacture(Position position);
        bool RemovePositionFromFacture(int positionId);
    }
}
