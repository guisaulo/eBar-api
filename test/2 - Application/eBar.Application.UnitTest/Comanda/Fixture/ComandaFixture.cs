using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Reflection;
using eBar.Application.Mappers;
using eBar.Domain.Core.Interfaces.Services;

namespace eBar.Application.UnitTest.Comanda.Fixture
{
    public class ComandaFixture
    {
        public readonly ApplicationServiceComanda Service;

        public ComandaFixture()
        {
            Service = new ApplicationServiceComanda(InicializaServiceComanda(), InicializarMapper());
        }

        private IServiceComanda InicializaServiceComanda()
        {
            var mock = new Mock<IServiceComanda>();
            mock.Setup(m => m.GetAll()).Returns(new List<Domain.Entities.Comanda>() { new Domain.Entities.Comanda { Id = 1, Nome = "Comanda 1"} });
            return mock.Object;
        }

        private static IMapper InicializarMapper()
        {
            var config = new MapperConfiguration(opts => { opts.AddMaps(Assembly.GetAssembly(typeof(ComandaProfile))); });
            return config.CreateMapper();
        }
    }
}