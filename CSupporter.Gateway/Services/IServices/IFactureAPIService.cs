using System.Threading.Tasks;

namespace CSupporter.Gateway.Services.IServices
{
    public interface IFactureAPIService
    {
        Task<string> GetFactureByIdAsync<T>(int factureId);
    }
}
