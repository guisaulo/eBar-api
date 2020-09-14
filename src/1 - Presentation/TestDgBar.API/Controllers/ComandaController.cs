using Microsoft.AspNetCore.Mvc;
using System;
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
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            try
            {
                return Ok(applicationServiceComanda.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}