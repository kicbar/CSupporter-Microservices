using CSupporter.Gateway.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSupporter.Gateway.Services
{
    public class ProductAPIService : BaseService, IProductAPIService
    {
        public Task<string> GetProductByIdAsync<T>(int contractorId)
        {
            throw new NotImplementedException();
        }
    }
}
