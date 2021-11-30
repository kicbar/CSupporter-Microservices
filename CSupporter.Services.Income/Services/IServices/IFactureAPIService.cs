using System.Threading.Tasks;

namespace CSupporter.Services.Income.Services.IServices
{
    public interface IFactureAPIService
    {
        Task<string> GetAllFactures<T>();
    }
}
