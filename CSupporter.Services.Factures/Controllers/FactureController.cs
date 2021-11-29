using CSupporter.Services.Factures.Models.Dtos;
using CSupporter.Services.Factures.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSupporter.Services.Factures.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FactureController : Controller
    {
        private readonly IFactureService _factureService;

        public FactureController(IFactureService factureService)
        {
            _factureService = factureService;
        }

        [HttpGet]
        [ActionName("GetAllFactures")]
        public ActionResult<List<FactureDto>> GetAllFactures()
        {
            return Ok(_factureService.GetAllFactures());
        }

        [HttpGet]
        [Route("{factureId}")]
        [ActionName("GetFactureById")]
        public ActionResult<FactureDto> GetFactureById(int factureId)
        {
            FactureDto factureDto = _factureService.GetFactureById(factureId);

            if (factureDto == null)
                return NotFound();

            return Ok(factureDto);
        }

        [HttpPost]
        [ActionName("CreateUpdateFacture")]
        public ActionResult<FactureDto> CreateUpdateFacture(FactureDto factureDto)
        {
            FactureDto createdFactureDto = _factureService.CreateUpdateFacture(factureDto);

            if (factureDto == null)
                return NotFound();

            return Created($"api/Facture/{createdFactureDto.FactureId}", null);
        }

        [HttpDelete]
        [Route("{factureId}")]
        [ActionName("DeleteFacture")]
        public ActionResult DeleteFacture(int factureId)
        {
            bool result = _factureService.DeleteFacture(factureId);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}
