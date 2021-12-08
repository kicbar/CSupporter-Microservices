using CSupporter.Gateway.Dtos;

namespace CSupporter.Gateway.Services.IServices
{
    public interface IGatewayService
    {
        FactureDto GetFactureWithDetailsAsync(int factureId);
    }
}
