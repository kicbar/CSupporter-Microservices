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
        public async Task<ActionResult<List<ContractorDto>>> GetContractorForFacture()
        {
            List<ContractorDto> contractorDtos = new List<ContractorDto>();
            var response = await _contractorService.GetAllContractorAsync<ContractorDto>();

            if (response != null)
            {
                contractorDtos = JsonConvert.DeserializeObject<List<ContractorDto>>(Convert.ToString(response));
            }

            return contractorDtos;
        }
    }
}
