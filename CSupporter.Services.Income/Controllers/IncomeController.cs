using CSupporter.Services.Income.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CSupporter.Services.Income.Controllers
{
    [ApiController]
    [Route("api/income")]
    public class IncomeController : Controller
    {
        private readonly IIncomeCalculateService _incomeCalculateService;

        public IncomeController(IIncomeCalculateService incomeCalculateService)
        {
            _incomeCalculateService = incomeCalculateService;
        }

        [HttpGet]
        [ActionName("CalculateIncome")]
        public ActionResult<double> CalculateIncome()
        {
            //calculate by period time
            return Ok(_incomeCalculateService.CalculateExecutor());
        }
    }
}
