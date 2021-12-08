using CSupporter.Gateway.Options;
using CSupporter.Gateway.Services.IServices;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSupporter.Gateway.Services
{
    public class ProductAPIService : BaseService, IProductAPIService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductAPIService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> GetProductByIdAsync<T>(int productId)
        {
            return await this.SendAsync<T>(new RequestAPI()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductsAPI + "api/product/" + productId
            });
        }
    }
}
