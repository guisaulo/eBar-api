using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TestDgBar.Application.Dtos;
using TestDgBar.Application.Interfaces;

namespace TestDgBar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ComandaItemController : ControllerBase
    {

        private readonly IApplicationServiceComandaItem applicationServiceComandaItem;

        public ComandaItemController(IApplicationServiceComandaItem applicationServiceComandaItem)
        {
            this.applicationServiceComandaItem = applicationServiceComandaItem;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceComandaItem.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(applicationServiceComandaItem.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] ComandaItemDto comandaItemDTO)
        {
            try
            {
                if (comandaItemDTO == null)
                    return NotFound();

                applicationServiceComandaItem.Add(comandaItemDTO);
                return Ok("ComandaItem Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] ComandaItemDto comandaItemDTO)
        {
            try
            {
                if (comandaItemDTO == null)
                    return NotFound();

                applicationServiceComandaItem.Update(comandaItemDTO);
                return Ok("ComandaItem Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] ComandaItemDto comandaItemDTO)
        {
            try
            {
                if (comandaItemDTO == null)
                    return NotFound();

                applicationServiceComandaItem.Remove(comandaItemDTO);
                return Ok("ComandaItem Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}