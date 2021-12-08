using System.Threading.Tasks;

namespace CSupporter.Gateway.Services.IServices
{
    public interface IProductAPIService
    {
        Task<string> GetProductByIdAsync<T>(int productId);
    }
}
