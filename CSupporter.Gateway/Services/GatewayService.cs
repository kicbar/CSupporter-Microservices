using CSupporter.Gateway.Dtos;
using CSupporter.Gateway.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSupporter.Gateway.Services
{
    public class GatewayService : IGatewayService
    {
        private readonly IContractorAPIService _contractorAPIService;
        private readonly IFactureAPIService _factureAPIService;
        private readonly IProductAPIService _productAPIService;

        public GatewayService(IContractorAPIService contractorAPIService, IFactureAPIService factureAPIService, IProductAPIService productAPIService)
        {
            _contractorAPIService = contractorAPIService;
            _factureAPIService = factureAPIService;
            _productAPIService = productAPIService;
        }

        public async Task<FactureDto> GetFactureWithDetailsAsync(int factureId)
        {
            FactureDto entireFactureDto = new();


            return entireFactureDto;
        }

        FactureDto IGatewayService.GetFactureWithDetailsAsync(int factureId)
        {
            throw new NotImplementedException();
        }
    }
}
