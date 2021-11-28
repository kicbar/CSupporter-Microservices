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
            return _contractorService.GetAllContractors();
        }
    }
}
