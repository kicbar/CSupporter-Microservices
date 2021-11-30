using CSupporter.Services.Factures.Models;
using CSupporter.Services.Factures.Models.Dtos;
using CSupporter.Services.Factures.Services.IServices;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSupporter.Services.Factures.Services
{
    public class ContractorAPIService : BaseService, IContractorAPIService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ContractorAPIService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> GetAllContractorAsync<T>()
        {
            return await this.SendAsync<T>(new RequestAPI()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ContractorsAPI + "api/Contractor"
            });
        }
    }
}
