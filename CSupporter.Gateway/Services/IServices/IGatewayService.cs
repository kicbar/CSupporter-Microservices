using CSupporter.Gateway.Dtos;
using System.Threading.Tasks;

namespace CSupporter.Gateway.Services.IServices
{
    public interface IGatewayService
    {
        Task<FactureDetailsDto> GetFactureWithDetailsAsync(int factureId);
    }
}
