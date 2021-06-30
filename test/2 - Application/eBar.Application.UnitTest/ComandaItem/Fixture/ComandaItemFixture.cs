using AutoMapper;
using Moq;
using System.Reflection;
using eBar.Application.Mappers;
using eBar.Domain.Core.Interfaces.Services;

namespace eBar.Application.UnitTest.ComandaItem.Fixture
{
    public class ComandaItemFixture
    {
        public readonly ApplicationServiceComandaItem Service;

        public ComandaItemFixture()
        {
            Service = new ApplicationServiceComandaItem(InicializaServiceComandaItem(), InicializarMapper());
        }

        private IServiceComandaItem InicializaServiceComandaItem()
        {
            var mock = new Mock<IServiceComandaItem>();
            mock.Setup(m => m.GerarNotaFiscalComanda(It.IsAny<int>()))
                .Returns(new Domain.Entities.NotaFiscalComanda { Items = new System.Collections.Generic.List<Domain.Entities.Item> { new Domain.Entities.Item { Id = 1, Nome = "Item 1", Valor = 20} }, Desconto = 5, ValorTotal = 15 });
            return mock.Object;
        }

        private static IMapper InicializarMapper()
        {
            var config = new MapperConfiguration(opts => { opts.AddMaps(Assembly.GetAssembly(typeof(ComandaItemProfile))); });
            return config.CreateMapper();
        }
    }
}
