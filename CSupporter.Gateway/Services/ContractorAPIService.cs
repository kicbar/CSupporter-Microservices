using CSupporter.Gateway.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSupporter.Gateway.Services
{
    public class ContractorAPIService : BaseService, IContractorAPIService
    {
        public Task<string> GetContractorByIdAsync<T>(int contractorId)
        {
            throw new NotImplementedException();
        }
    }
}
