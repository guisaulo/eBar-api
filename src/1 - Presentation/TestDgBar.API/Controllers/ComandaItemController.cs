using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpPost("ResetarComanda")]
        public ActionResult ResetarComanda(int comandaId)
        {
            try
            {
                applicationServiceComandaItem.ResetarComanda(comandaId);
                return Ok("Comanda resetada com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost("InserirItemComanda")]
        public ActionResult InserirItemComanda([FromBody] ComandaItemDto comandaItemDTO)
        {
            try
            {
                if (comandaItemDTO == null)
                    return NotFound();

                applicationServiceComandaItem.InserirItemComanda(comandaItemDTO);
                return Ok("Item cadastrado com sucesso na comanda!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost("GerarNotaFiscalComanda")]
        public ActionResult<string> GerarNotaFiscalComanda(int comandaId)
        {
            return Ok(applicationServiceComandaItem.GerarNotaFiscalComanda(comandaId));
        }
    }
}