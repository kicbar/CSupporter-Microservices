using System.Threading.Tasks;

namespace CSupporter.Gateway.Services.IServices
{
    public interface IPositionAPIService
    {
        Task<string> GetPositionsForFacturesById<T>(int factureId);
    }
}
