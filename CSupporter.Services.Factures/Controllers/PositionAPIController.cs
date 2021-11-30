using CSupporter.Services.Factures.Models;
using CSupporter.Services.Factures.Models.Dtos;
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

        [HttpPost]
        [ActionName("CreatePositionForFacture")]
        public ActionResult<PositionDto> CreatePositionForFacture([FromBody] PositionDto positionDto, int factureId)
        {
            return Ok(_positionService.AddPositionToFacture(positionDto, factureId));
        }

        [HttpDelete]
        [Route("factureId")]
        [ActionName("RemovePositionFromFacture")]
        public ActionResult<PositionDto> RemovePositionFromFacture(int positionId)
        {
            return Ok(_positionService.RemovePositionFromFacture(positionId));
        }
    }
}
