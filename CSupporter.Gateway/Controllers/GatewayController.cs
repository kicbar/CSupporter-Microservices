using CSupporter.Gateway.Dtos;
using CSupporter.Gateway.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CSupporter.Gateway.Controllers
{
    [ApiController]
    [Route("api/gateway")]
    public class GatewayController : Controller
    {
        private readonly IGatewayService _gatewayService;

        public GatewayController(IGatewayService gatewayService)
        {
            _gatewayService = gatewayService;
        }

        [HttpGet]
        [Route("/api/gateway/facture/{factureId}")]
        [ActionName("GetFactureWithDetails")]
        public async Task<ActionResult<FactureDetailsDto>> GetFactureWithDetails(int factureId)
        {
            FactureDetailsDto factureDetailsDto = await _gatewayService.GetFactureWithDetailsAsync(factureId);
            return factureDetailsDto;
        }
    }
}
