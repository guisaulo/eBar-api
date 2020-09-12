using Moq;
using TestDgBar.Domain.Core.Interfaces.Repositories;
using TestDgBar.Domain.Services.UnitTest.Comanda.Faker;

namespace TestDgBar.Domain.Services.UnitTest.Comanda.Fixture
{
    public class ComandaFixture
    {
        public readonly ServiceComanda Service;

        public ComandaFixture()
        {
            Service = new ServiceComanda(InicializaIRepositoryComanda());
        }

        private IRepositoryComanda InicializaIRepositoryComanda()
        {
            var mock = new Mock<IRepositoryComanda>();

            mock.Setup(m => m.GetAll()).Returns(ComandaFaker.GetComandasAsQueryable());

            return mock.Object;
        }
    }
}