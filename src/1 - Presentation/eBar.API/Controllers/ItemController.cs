using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using eBar.API.Extensions;
using eBar.Application.Interfaces;

namespace eBar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly IApplicationServiceItem applicationServiceItem;

        public ItemController(IApplicationServiceItem applicationServiceItem)
        {
            this.applicationServiceItem = applicationServiceItem;
        }
        // GET api/values
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            try
            {
                return PoliciesExtensions.RetryPolicy().Execute(() =>
                    Ok(applicationServiceItem.GetAll())
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}