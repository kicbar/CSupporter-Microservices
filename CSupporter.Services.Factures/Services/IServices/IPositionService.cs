using CSupporter.Services.Factures.Models;
using CSupporter.Services.Factures.Models.Dtos;
using System.Collections.Generic;

namespace CSupporter.Services.Factures.Services.IServices
{
    public interface IPositionService
    {
        List<PositionDto> GetAllPositionsForFacture(int factureId);
        PositionDto AddPositionToFacture(PositionDto positionDto, int factureId);
        bool DeletePositionFromFacture(int positionId);
    }
}
