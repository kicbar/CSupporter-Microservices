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
    [Route("api/facture/contractor")]
    public class ContractorController : Controller
    {
        private readonly IContractorAPIService _contractorService;

        public ContractorController(IContractorAPIService contractorService)
        {
            _contractorService = contractorService;
        }

        [HttpGet]
        [ActionName("GetAllContractorsForFactures")]
        public async Task<ActionResult<List<ContractorDto>>> GetAllContractorsForFactures()
        {
            List<ContractorDto> contractorDtos = new List<ContractorDto>();
            var response = await _contractorService.GetAllContractorsAsync<ContractorDto>();

            if (response != null)
            {
                contractorDtos = JsonConvert.DeserializeObject<List<ContractorDto>>(Convert.ToString(response));
            }

            return contractorDtos;
        }

        [HttpGet]
        [Route("{contractorId}")]
        [ActionName("GetContractorForFacture")]
        public async Task<ActionResult<ContractorDto>> GetContractorForFacture(int contractorId)
        {
            ContractorDto contractorDto = new ContractorDto();
            var response = await _contractorService.GetContractorByIdAsync<ContractorDto>(contractorId);

            if (response != null)
            {
                contractorDto = JsonConvert.DeserializeObject<ContractorDto>(Convert.ToString(response));
            }

            return contractorDto;
        }
    }
}
