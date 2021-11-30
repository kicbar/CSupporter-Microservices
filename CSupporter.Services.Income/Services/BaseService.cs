using CSupporter.Services.Income.Models;
using CSupporter.Services.Income.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSupporter.Services.Income.Services
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
                HttpRequestMessage message = new HttpRequestMessage();
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
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
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

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
