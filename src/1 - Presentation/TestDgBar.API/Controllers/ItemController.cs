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

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(applicationServiceItem.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] ItemDto itemDTO)
        {
            try
            {
                if (itemDTO == null)
                    return NotFound();

                applicationServiceItem.Add(itemDTO);
                return Ok("Item Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] ItemDto itemDTO)
        {
            try
            {
                if (itemDTO == null)
                    return NotFound();

                applicationServiceItem.Update(itemDTO);
                return Ok("Item Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] ItemDto itemDTO)
        {
            try
            {
                if (itemDTO == null)
                    return NotFound();

                applicationServiceItem.Remove(itemDTO);
                return Ok("Item Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}