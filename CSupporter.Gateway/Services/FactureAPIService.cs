using CSupporter.Gateway.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSupporter.Gateway.Services
{
    public class FactureAPIService : BaseService, IFactureAPIService
    {
        public Task<string> GetFactureByIdAsync<T>(int factureId)
        {
            throw new NotImplementedException();
        }
    }
}
