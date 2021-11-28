using CSupporter.Services.Contractors.Models.Dtos;
using CSupporter.Services.Contractors.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSupporter.Services.Contractors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorController : Controller
    {
        private readonly IContractorService _contractorService;

        public ContractorController(IContractorService contractorService)
        {
            _contractorService = contractorService;
        }

        [HttpGet]
        [ActionName("GetAllContractors")]
        public ActionResult<List<ContractorDto>> GetAllContractors()
        {
            List<ContractorDto> contractorsDto = _contractorService.GetAllContractors();
            return Ok(contractorsDto);
        }

        [HttpGet]
        [Route("{contractorId}")]
        [ActionName("GetContractorById")]
        public ActionResult<ContractorDto> GetContractorById(int contractorId)
        {
            ContractorDto contractorDto = _contractorService.GetContractorById(contractorId);

            if (contractorDto == null)
            {
                return NotFound();
            }

            return Ok(contractorDto);
        }
    }
}
