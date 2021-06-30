using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using eBar.API.Extensions;
using eBar.Application.Interfaces;

namespace eBar.API.Controllers
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
                return PoliciesExtensions.RetryPolicy().Execute(() => 
                    Ok(applicationServiceComanda.GetAll())                
                );

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}