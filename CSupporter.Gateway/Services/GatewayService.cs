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

        public async Task<FactureDetailsDto> GetFactureWithDetailsAsync(int factureId)
        {
            FactureDetailsDto factureDetailsDto = new();
            int contractorIdForFacture = 0;

            var responseFacture = await _factureAPIService.GetFactureByIdAsync<FactureDto>(factureId);

            if (responseFacture != null)
            {
                FactureDto factureDto = JsonConvert.DeserializeObject<FactureDto>(Convert.ToString(responseFacture));
                factureDetailsDto.FactureNo = factureDto.FactureNo;
                factureDetailsDto.FactureValue = factureDto.Value;
                factureDetailsDto.FactureType = factureDto.FactureType;
                factureDetailsDto.FactureDate = factureDto.FactureDate;
                contractorIdForFacture = factureDto.ContractorId;
            }

            var responseContractor = await _contractorAPIService.GetContractorByIdAsync<ContractorDto>(contractorIdForFacture);
            if (responseContractor != null)
            {
                ContractorDto contractorDto = JsonConvert.DeserializeObject<ContractorDto>(Convert.ToString(responseContractor));
                factureDetailsDto.ContractorCompanyName = contractorDto.CompanyName;
                factureDetailsDto.ContractorFirstName = contractorDto.FirstName;
                factureDetailsDto.ContractorLastName = contractorDto.LastName;
                factureDetailsDto.ContractorNIP = contractorDto.NIP;
                factureDetailsDto.ContractorAddress = contractorDto.Address;
            }

            return factureDetailsDto;
        }
    }
}
