using CSupporter.Gateway.Options;
using CSupporter.Gateway.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSupporter.Gateway.Services
{
    public class BaseService : IBaseService
    {
        public IHttpClientFactory httpClient;

        public BaseService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> SendAsync<T>(RequestAPI requestAPI)
        {
            try
            {
                var client = httpClient.CreateClient("CSupprterAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(requestAPI.Url);
                client.DefaultRequestHeaders.Clear();

                if (requestAPI.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestAPI.Data), Encoding.UTF8, "application/json");
                }
                HttpResponseMessage apiResponse = null;

                switch (requestAPI.ApiType)
                {
                    case SD.ApiType.GET:
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                return apiContent;
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        public void Dispose() => GC.SuppressFinalize(true);
    }
}
