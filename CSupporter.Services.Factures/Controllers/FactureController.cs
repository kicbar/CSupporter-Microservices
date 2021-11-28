using CSupporter.Services.Factures.Models.Dtos;
using CSupporter.Services.Factures.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSupporter.Services.Factures.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FactureController
    {
        private readonly IFactureService _factureService;

        public FactureController(IFactureService factureService)
        {
            _factureService = factureService;
        }

        [HttpGet]
        [ActionName("GetAllFactures")]
        public List<FactureDto> GetAllFactures()
        {
            return _factureService.GetAllFactures();
        }
    }
}
