using CSupporter.Services.Factures.Models;
using System.Collections.Generic;

namespace CSupporter.Services.Factures.Repositories.IRepositories
{
    public interface IFactureRepository
    {
        List<Facture> GetAllFactures();
        Facture GetFactureById(int factureId);
        Facture CreateUpdateFacture(Facture facture);
        bool DeleteFacture(int factureId);
        void CalculateFacturesValue();
    }
}
