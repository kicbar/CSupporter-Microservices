using CSupporter.Services.Factures.Models.Dtos;
using System.Collections.Generic;

namespace CSupporter.Services.Factures.Services.IServices
{
    public interface IFactureService
    {
        List<FactureDto> GetAllFactures();
        FactureDto GetFactureById(int contractorId);
    }
}
