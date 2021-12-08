using System.Threading.Tasks;

namespace CSupporter.Gateway.Services.IServices
{
    public interface IContractorAPIService
    {
        Task<string> GetContractorByIdAsync<T>(int contractorId);
    }
}
