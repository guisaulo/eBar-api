using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TestDgBar.Application.Dtos;
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
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceItem.GetAll());
        }
    }
}