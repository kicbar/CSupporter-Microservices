using CSupporter.Services.Factures.Models.Dtos;
using System.Threading.Tasks;

namespace CSupporter.Services.Factures.Services.IServices
{
    public interface IContractorAPIService
    {
        Task<string> GetAllContractorAsync<T>();
    }
}
