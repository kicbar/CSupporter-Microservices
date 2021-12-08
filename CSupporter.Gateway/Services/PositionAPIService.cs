using CSupporter.Gateway.Options;
using CSupporter.Gateway.Services.IServices;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSupporter.Gateway.Services
{
    public class PositionAPIService : BaseService, IPositionAPIService
    {
        private readonly IHttpClientFactory _clientFactory;

        public PositionAPIService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> GetPositionsForFacturesById<T>(int factureId)
        {
            return await this.SendAsync<T>(new RequestAPI()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.FacturesAPI + "api/position/factureId?factureId=" + factureId
            });
        }
    }
}
