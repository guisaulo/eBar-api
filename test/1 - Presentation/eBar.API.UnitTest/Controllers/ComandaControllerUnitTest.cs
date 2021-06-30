using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using eBar.API.Controllers;
using eBar.Application.Interfaces;
using Xunit;

namespace eBar.API.UnitTest
{
    public class ComandaControllerUnitTest
    {
        [Fact]
        public void Deve_Validar_Retorno_OK_Ao_Executar_Metodo_GetAll_Comandas()
        {
            var controller = new ComandaController(new Mock<IApplicationServiceComanda>().Object);
            var actionResult = controller.GetAll();
            Assert.IsType<ActionResult<IEnumerable<string>>>(actionResult);
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public void Deve_Validar_Retorno_BadRequest_Ao_Executar_Metodo_GetAll_Comandas()
        {
            var controller = new ComandaController(InicializaApplicationServiceComandaValidationException());
            var actionResult = controller.GetAll();
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        private IApplicationServiceComanda InicializaApplicationServiceComandaValidationException()
        {
            var mock = new Mock<IApplicationServiceComanda>();
            mock.Setup(m => m.GetAll())
                .Throws(new Exception());
            return mock.Object;
        }
    }
}