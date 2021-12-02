using System.Threading.Tasks;

namespace CSupporter.Services.Contractors.Services.IServices
{
    public interface IFactureAPIService
    {
        Task<string> GetFactureForContractorAsync<T>(int contractorId);
    }
}
