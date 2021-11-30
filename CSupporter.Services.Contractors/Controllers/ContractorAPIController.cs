using CSupporter.Services.Contractors.Models.Dtos;
using CSupporter.Services.Contractors.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSupporter.Services.Contractors.Controllers
{
    [ApiController]
    [Route("api/contractor")]
    public class ContractorAPIController : Controller
    {
        private readonly IContractorService _contractorService;

        public ContractorAPIController(IContractorService contractorService)
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

        [HttpPost]
        [ActionName("CreateUpdateContractor")]
        public ActionResult CreateUpdateContractor([FromBody] ContractorDto contractorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ContractorDto createdContracor = _contractorService.CreateUpdateContractor(contractorDto);

            return Created($"api/Contractor/{createdContracor.ContractorId}", null);
        }

        [HttpDelete]
        [Route("{contractorId}")]
        [ActionName("DeleteContractor")]
        public ActionResult DeleteContractor(int contractorId)
        {
            bool result = _contractorService.DeleteContractor(contractorId);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}
