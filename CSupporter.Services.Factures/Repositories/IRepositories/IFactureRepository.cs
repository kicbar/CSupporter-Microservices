using CSupporter.Services.Factures.Models;
using System.Collections.Generic;

namespace CSupporter.Services.Factures.Repositories.IRepositories
{
    public interface IFactureRepository
    {
        List<Facture> GetAllFactures();
        Facture GetFactureById(int contractorId);
    }
}
