using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Reflection;
using eBar.Application.Mappers;
using eBar.Domain.Core.Interfaces.Services;

namespace eBar.Application.UnitTest.Item.Fixture
{
    public class ItemFixture
    {
        public readonly ApplicationServiceItem Service;

        public ItemFixture()
        {
            Service = new ApplicationServiceItem(InicializaServiceItem(), InicializarMapper());
        }

        private IServiceItem InicializaServiceItem()
        {
            var mock = new Mock<IServiceItem>();
            mock.Setup(m => m.GetAll()).Returns(new List<Domain.Entities.Item>() { new Domain.Entities.Item { Id = 1, Nome = "Cerveja", Valor = 5 } });
            return mock.Object;
        }

        private static IMapper InicializarMapper()
        {
            var config = new MapperConfiguration(opts => { opts.AddMaps(Assembly.GetAssembly(typeof(ItemProfile))); });
            return config.CreateMapper();
        }
    }
}