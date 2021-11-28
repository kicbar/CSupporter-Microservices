using CSupporter.Services.Contractors.Models;
using System.Collections.Generic;

namespace CSupporter.Services.Contractors.Repositories.IRepositories
{
    public interface IContractorRepository
    {
        List<Contractor> GetAllContractors();
    }
}
