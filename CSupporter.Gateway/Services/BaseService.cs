using CSupporter.Gateway.Options;
using CSupporter.Gateway.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSupporter.Gateway.Services
{
    public class BaseService : IBaseService
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<string> SendAsync<T>(RequestAPI requestAPI)
        {
            throw new NotImplementedException();
        }
    }
}
