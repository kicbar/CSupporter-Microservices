using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSupporter.Services.Contractors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorController : Controller
    {
        public ContractorController()
        {

        }

        [HttpGet]
        [ActionName("GetAllContractors")]
        public ActionResult<string> GetAllContractors()
        {
            return ("Zwracam wszystkich kotraktorów");
        }
    }
}
