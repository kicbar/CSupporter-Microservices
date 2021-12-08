using CSupporter.Gateway.Options;
using CSupporter.Gateway.Services.IServices;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSupporter.Gateway.Services
{
    public class FactureAPIService : BaseService, IFactureAPIService
    {
        private readonly IHttpClientFactory _clientFactory;

        public FactureAPIService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> GetFactureByIdAsync<T>(int factureId)
        {
            return await this.SendAsync<T>(new RequestAPI()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.FacturesAPI + "api/facture/" + factureId
            });
        }
    }
}
