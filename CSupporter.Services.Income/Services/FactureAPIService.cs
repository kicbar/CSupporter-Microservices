using CSupporter.Services.Income.Models;
using CSupporter.Services.Income.Services.IServices;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSupporter.Services.Income.Services
{
    public class FactureAPIService : BaseService, IFactureAPIService
    {
        private readonly IHttpClientFactory _clientFactory;

        public FactureAPIService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> GetAllFactures<T>()
        {
            return await this.SendAsync<T>(new RequestAPI()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.FacturesAPI + "api/facture"
            });
        }
    }
}
