using CSupporter.Gateway.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CSupporter.Gateway.Controllers
{
    [ApiController]
    [Route("api/gateway")]
    public class GatewayController : Controller
    {
        public GatewayController()
        {

        }

        [HttpGet]
        [Route("/api/gateway/facture")]
        [ActionName("GetFactureWithDetails")]
        public ActionResult<FactureDto> GetFactureWithDetails()
        {
            return Ok("Return facture dto");
        }
    }
}
