using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using eBar.API.Controllers;
using eBar.Application.Interfaces;
using Xunit;

namespace eBar.API.UnitTest.Controllers
{
    public class ItemControllerUnitTest
    {
        [Fact]
        public void Deve_Validar_Retorno_OK_Ao_Executar_Metodo_GetAll_Items()
        {
            var controller = new ItemController(new Mock<IApplicationServiceItem>().Object);
            var actionResult = controller.GetAll();
            Assert.IsType<ActionResult<IEnumerable<string>>>(actionResult);
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public void Deve_Validar_Retorno_BadRequest_Ao_Executar_Metodo_GetAll_Items()
        {
            var controller = new ItemController(InicializaApplicationServiceItemValidationException());
            var actionResult = controller.GetAll();
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        private IApplicationServiceItem InicializaApplicationServiceItemValidationException()
        {
            var mock = new Mock<IApplicationServiceItem>();
            mock.Setup(m => m.GetAll())
                .Throws(new Exception());
            return mock.Object;
        }
    }
}