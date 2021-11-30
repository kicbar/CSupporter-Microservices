using CSupporter.Services.Income.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSupporter.Services.Income.Controllers
{
    [ApiController]
    public class IncomeController : Controller
    {
        private readonly IFactureAPIService _factureAPIService;

        public IncomeController(IFactureAPIService factureAPIService)
        {
            _factureAPIService = factureAPIService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            //calculate by period time
            return View();
        }
    }
}
