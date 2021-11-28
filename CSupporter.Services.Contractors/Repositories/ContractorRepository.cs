using CSupporter.Services.Contractors.Data.DbContexts;
using CSupporter.Services.Contractors.Models;
using CSupporter.Services.Contractors.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSupporter.Services.Contractors.Repositories
{
    public class ContractorRepository : IContractorRepository
    {
        private readonly ContractorDbContext _contractorDbContext;

        public ContractorRepository(ContractorDbContext contractorDbContext)
        {
            _contractorDbContext = contractorDbContext;
        }

        public List<Contractor> GetAllContractors()
        {
            return _contractorDbContext.Contractors.ToList();
        }
    }
}
