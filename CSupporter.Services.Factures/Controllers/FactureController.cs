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
        [Route("{contractorId}")]
        [ActionName("GetFactureById")]
        public ActionResult<FactureDto> GetFactureById(int contractorId)
        {
            FactureDto factureDto = _factureService.GetFactureById(contractorId);

            if (factureDto == null)
                return NotFound();

            return Ok(factureDto);
        }
    }
}
