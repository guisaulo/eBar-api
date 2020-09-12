using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestDgBar.Application.Interfaces;

namespace TestDgBar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {

        private readonly IApplicationServiceComanda applicationServiceComanda;

        public ComandaController(IApplicationServiceComanda applicationServiceComanda)
        {
            this.applicationServiceComanda = applicationServiceComanda;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceComanda.GetAll());
        }
    }
}