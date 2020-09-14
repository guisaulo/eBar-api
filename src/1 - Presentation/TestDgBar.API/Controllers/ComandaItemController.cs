using Microsoft.AspNetCore.Mvc;
using System;
using TestDgBar.API.Extensions;
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

        [HttpPost("InserirItemComanda")]
        public ActionResult InserirItemComanda([FromBody] ComandaItemDto comandaItemDTO)
        {
            try
            {
                if (comandaItemDTO == null)
                    return NotFound(Properties.Resource.ComandaItemDTONotFound);

                return PoliciesExtensions.RetryPolicy().Execute(() =>
                {
                    applicationServiceComandaItem.InserirItemComanda(comandaItemDTO);
                    return Ok(Properties.Resource.ItemCadastradoComSucesso);
                });

                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ResetarComanda")]
        public ActionResult ResetarComanda(int comandaId)
        {
            try
            {
                return PoliciesExtensions.RetryPolicy().Execute(() =>
                {
                    applicationServiceComandaItem.ResetarComanda(comandaId);
                    return Ok(Properties.Resource.ComandaResetadaComSucesso);
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GerarNotaFiscalComanda")]
        public ActionResult<string> GerarNotaFiscalComanda(int comandaId)
        {
            try
            {
                return PoliciesExtensions.RetryPolicy().Execute(() =>
                    Ok(applicationServiceComandaItem.GerarNotaFiscalComanda(comandaId))
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}