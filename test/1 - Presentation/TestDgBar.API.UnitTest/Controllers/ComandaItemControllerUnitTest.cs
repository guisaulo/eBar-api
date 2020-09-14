using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestDgBar.API.Controllers;
using TestDgBar.API.Properties;
using TestDgBar.Application.Dtos;
using TestDgBar.Application.Interfaces;
using Xunit;

namespace TestDgBar.API.UnitTest.Controllers
{
    public class ComandaItemControllerUnitTest
    {
        [Fact]
        public void Deve_Validar_Retorno_OK_Ao_Executar_Metodo_InserirItemComanda()
        {
            var controller = new ComandaItemController(new Mock<IApplicationServiceComandaItem>().Object);
            var actionResult = controller.InserirItemComanda(new ComandaItemDto() { ComandaId = 1, ItemId = 1});
            Assert.IsType<OkObjectResult>(actionResult);
            var okResult = actionResult as OkObjectResult;
            Assert.Equal(okResult.Value, Resource.ItemCadastradoComSucesso);
        }

        [Fact]
        public void Deve_Validar_Retorno_NotFound_Ao_Executar_Metodo_InserirItemComanda()
        {
            var controller = new ComandaItemController(new Mock<IApplicationServiceComandaItem>().Object);
            var actionResult = controller.InserirItemComanda(default);
            Assert.IsType<NotFoundObjectResult>(actionResult);
            var okResult = actionResult as NotFoundObjectResult;
            Assert.Equal(okResult.Value, Resource.ComandaItemDTONotFound);
        }

        [Fact]
        public void Deve_Validar_Retorno_BadRequest_Ao_Executar_Metodo_InserirItemComanda()
        {
            var controller = new ComandaItemController(InicializaApplicationServiceComandaIteValidationException());
            var actionResult = controller.InserirItemComanda(new ComandaItemDto() { ComandaId = 1, ItemId = 99 });
            Assert.IsType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public void Deve_Validar_Retorno_OK_Ao_Executar_Metodo_ResetarComanda()
        {
            var controller = new ComandaItemController(new Mock<IApplicationServiceComandaItem>().Object);
            var actionResult = controller.ResetarComanda(1);
            Assert.IsType<OkObjectResult>(actionResult);
            var okResult = actionResult as OkObjectResult;
            Assert.Equal(okResult.Value, Resource.ComandaResetadaComSucesso);
        }

        [Fact]
        public void Deve_Validar_Retorno_BadRequest_Ao_Executar_Metodo_ResetarComanda()
        {
            var controller = new ComandaItemController(InicializaApplicationServiceComandaIteValidationException());
            var actionResult = controller.ResetarComanda(99);
            Assert.IsType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public void Deve_Validar_Retorno_OK_Ao_Executar_Metodo_GerarNotaFiscalComanda()
        {
            var controller = new ComandaItemController(new Mock<IApplicationServiceComandaItem>().Object);
            var actionResult = controller.GerarNotaFiscalComanda(1);
            Assert.IsType<ActionResult<string>>(actionResult);
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public void Deve_Validar_Retorno_BadRequest_Ao_Executar_Metodo_GerarNotaFiscalComanda()
        {
            var controller = new ComandaItemController(InicializaApplicationServiceComandaIteValidationException());
            var actionResult = controller.GerarNotaFiscalComanda(99);
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        private IApplicationServiceComandaItem InicializaApplicationServiceComandaIteValidationException()
        {
            var mock = new Mock<IApplicationServiceComandaItem>();
            mock.Setup(m => m.InserirItemComanda(It.IsAny<ComandaItemDto>()))
                .Throws(new ValidationException());
            mock.Setup(m => m.ResetarComanda(It.IsAny<int>()))
                .Throws(new ValidationException());
            mock.Setup(m => m.GerarNotaFiscalComanda(It.IsAny<int>()))
                .Throws(new ValidationException());
            return mock.Object;
        }
    }
}