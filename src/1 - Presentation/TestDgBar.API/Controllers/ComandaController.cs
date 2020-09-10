using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TestDgBar.Application.Dtos;
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

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(applicationServiceComanda.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] ComandaDto comandaDTO)
        {
            try
            {
                if (comandaDTO == null)
                    return NotFound();

                applicationServiceComanda.Add(comandaDTO);
                return Ok("Comanda Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] ComandaDto comandaDTO)
        {
            try
            {
                if (comandaDTO == null)
                    return NotFound();

                applicationServiceComanda.Update(comandaDTO);
                return Ok("Comanda Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] ComandaDto comandaDTO)
        {
            try
            {
                if (comandaDTO == null)
                    return NotFound();

                applicationServiceComanda.Remove(comandaDTO);
                return Ok("Comanda Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}