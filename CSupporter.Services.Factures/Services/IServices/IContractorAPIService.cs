using System.Threading.Tasks;

namespace CSupporter.Services.Factures.Services.IServices
{
    public interface IContractorAPIService
    {
        Task<string> GetAllContractorsAsync<T>();

        Task<string> GetContractorByIdAsync<T>(int contractorId);
    }
}
