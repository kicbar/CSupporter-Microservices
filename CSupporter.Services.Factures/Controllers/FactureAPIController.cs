using CSupporter.Services.Factures.Models.Dtos;
using CSupporter.Services.Factures.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSupporter.Services.Factures.Controllers
{
    [ApiController]
    [Route("api/facture")]
    public class FactureAPIController : Controller
    {
        private readonly IContractorAPIService _contractorAPIService;
        private readonly IPositionService _positionService;
        private readonly IFactureService _factureService;

        public FactureAPIController(IFactureService factureService, IContractorAPIService contractorAPIService, IPositionService positionService)
        {
            _contractorAPIService = contractorAPIService;
            _positionService = positionService;
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

        [HttpGet]
        [Route("details/{factureId}")]
        [ActionName("GetFactureDetails")]
        public async Task<ActionResult<EntireFactureDto>> GetFactureDetails(int factureId)
        {
            EntireFactureDto entireFactureDto = new ();
            FactureDto factureDto = _factureService.GetFactureById(factureId);
            if (factureDto != null)
            { 
                entireFactureDto.FactureId = factureDto.FactureId;
                entireFactureDto.FactureNo = factureDto.FactureNo;
                entireFactureDto.FactureType = factureDto.FactureType;
                entireFactureDto.FactureDate = factureDto.FactureDate;
                entireFactureDto.FactureValue = factureDto.Value;
                var response = await _contractorAPIService.GetContractorByIdAsync<ContractorDto>(factureDto.ContractorId);

                if (response != null)
                {
                    ContractorDto contractorDto = JsonConvert.DeserializeObject<ContractorDto>(Convert.ToString(response));
                    entireFactureDto.ContractorFirstName = contractorDto.FirstName;
                    entireFactureDto.ContractorLastName= contractorDto.LastName;
                    entireFactureDto.ContractorCompanyName = contractorDto.CompanyName;
                    entireFactureDto.ContractorAddress = contractorDto.Address;
                    entireFactureDto.ContractorNIP = contractorDto.NIP;
                }
                else
                    return NotFound();

                List<PositionDto> positionDtos = _positionService.GetAllPositionsForFacture(factureId);
                entireFactureDto.Positions = positionDtos;
            }
            else
                return NotFound();

            return entireFactureDto;
        }

        [HttpPost]
        [ActionName("CreateUpdateFacture")]
        public ActionResult<FactureDto> CreateUpdateFacture(FactureDto factureDto)
        {
            FactureDto createdFactureDto = _factureService.CreateUpdateFacture(factureDto);

            if (factureDto == null)
                return NotFound();

            return Created($"api/facture/{createdFactureDto.FactureId}", null);
        }

        [HttpPost]
        [Route("CalculateFacturesValue")]
        [ActionName("CalculateFacturesValue")]
        public ActionResult<FactureDto> CalculateFacturesValue()
        {
            _factureService.CalculateFacturesValue();
            return Ok();
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

        [HttpGet]
        [Route("contractor/{contractorId}")]
        [ActionName("FacturesForContractor")]
        public ActionResult<bool> FacturesForContractor(int contractorId)
        {
            return Ok(_factureService.GetFacturesForContractor(contractorId));
        }

    }
}
