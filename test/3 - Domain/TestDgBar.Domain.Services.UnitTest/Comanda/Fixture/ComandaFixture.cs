using Moq;
using System.Linq;
using TestDgBar.Domain.Core.Interfaces.Repositories;
using TestDgBar.Domain.Services.UnitTest.Comanda.Faker;

namespace TestDgBar.Domain.Services.UnitTest.Comanda.Fixture
{
    public class ComandaFixture
    {
        public readonly ServiceComanda Service;

        public ComandaFixture()
        {
            Service = new ServiceComanda(InicializaRepositoryComanda());
        }

        private IRepositoryComanda InicializaRepositoryComanda()
        {
            var mock = new Mock<IRepositoryComanda>();
            mock.Setup(m => m.GetAll()).Returns(ComandaFaker.GetComandasAsQueryable());
            mock.Setup(m => m.GetById(It.IsAny<int>())).Returns((int id) => GetComandaById(id));
            return mock.Object;
        }

        private Entities.Comanda GetComandaById(int id)
        {
            var Comanda = ComandaFaker.GetComandasAsQueryable().ToList().FirstOrDefault(x => x.Id == id);
            return Comanda;
        }
    }
}