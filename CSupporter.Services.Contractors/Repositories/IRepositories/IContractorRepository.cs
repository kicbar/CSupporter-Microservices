using CSupporter.Services.Contractors.Models;
using System.Collections.Generic;

namespace CSupporter.Services.Contractors.Repositories.IRepositories
{
    public interface IContractorRepository
    {
        List<Contractor> GetAllContractors();
        Contractor GetContractorById(int contractorId);
        Contractor CreateUpdateContractor(Contractor contractor);
        bool DeleteContractor(Contractor contractor);
    }
}
