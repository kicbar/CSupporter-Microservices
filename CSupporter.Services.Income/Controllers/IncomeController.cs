﻿using CSupporter.Services.Income.Models.Dtos;
using CSupporter.Services.Income.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSupporter.Services.Income.Controllers
{
    [ApiController]
    [Route("api/income")]
    public class IncomeController : Controller
    {
        private readonly IFactureAPIService _factureAPIService;

        public IncomeController(IFactureAPIService factureAPIService)
        {
            _factureAPIService = factureAPIService;
        }

        [HttpGet]
        [ActionName("CalculateIncome")]
        public async Task<ActionResult<double>> CalculateIncome()
        {
            //calculate by period time
            double calculatedIncome = 0;

            var response = await _factureAPIService.GetAllFactures<FactureDto>();
            if (response != null)
            {
                List<FactureDto> factureDtos = JsonConvert.DeserializeObject<List<FactureDto>>(Convert.ToString(response));
            }

            return Ok(calculatedIncome);
        }
    }
}
