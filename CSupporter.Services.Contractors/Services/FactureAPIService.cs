using CSupporter.Services.Contractors.Models;
using CSupporter.Services.Contractors.Services.IServices;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSupporter.Services.Contractors.Services
{
    public class FactureAPIService : BaseService, IFactureAPIService
    {
        private readonly IHttpClientFactory _clientFactory;

        public FactureAPIService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<string> GetFactureForContractorAsync<T>(int contractorId)
        {
            string url = SD.FacturesAPI + $"api/facture/contractor/{contractorId}";
            return await this.SendAsync<T>(new RequestAPI()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.FacturesAPI + $"api/facture/contractor/{contractorId}"
            });
        }
    }
}
