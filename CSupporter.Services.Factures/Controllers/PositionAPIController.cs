using CSupporter.Services.Factures.Models;
using CSupporter.Services.Factures.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSupporter.Services.Factures.Controllers
{
    [ApiController]
    [Route("api/position")]
    public class PositionAPIController : Controller
    {
        private readonly IPositionService _positionService;

        public PositionAPIController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        [Route("factureId")]
        [ActionName("GetAllPositionsForFacture")]
        public ActionResult<List<Position>> GetAllPositionsForFacture(int factureId)
        {
            return Ok(_positionService.GetAllPositionsForFacture(factureId));
        }
    }
}
