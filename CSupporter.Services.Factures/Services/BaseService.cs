using CSupporter.Services.Factures.Models;
using CSupporter.Services.Factures.Models.Dtos;
using CSupporter.Services.Factures.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSupporter.Services.Factures.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<T> SendAsync<T>(RequestAPI requestAPI)
        {
            throw new NotImplementedException();
        }
    }
}
