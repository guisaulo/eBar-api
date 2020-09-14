using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TestDgBar.API.Extensions;
using TestDgBar.Application.Interfaces;

namespace TestDgBar.API.Controllers
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