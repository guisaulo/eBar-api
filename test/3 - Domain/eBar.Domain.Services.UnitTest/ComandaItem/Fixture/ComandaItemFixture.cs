using Moq;
using System.Linq;
using eBar.Domain.Core.Interfaces.Repositories;
using eBar.Domain.Core.Interfaces.Services;
using eBar.Domain.Services.UnitTest.Comanda.Faker;
using eBar.Domain.Services.UnitTest.ComandaItemItem.Faker;
using eBar.Domain.Services.UnitTest.Item.Faker;

namespace eBar.Domain.Services.UnitTest.ComandaItemItem.Fixture
{
    public class ComandaItemFixture
    {
        public readonly ServiceComandaItem Service;

        public ComandaItemFixture()
        {
            Service = new ServiceComandaItem(InicializaRepositoryComandaItem(), InicializaServiceComandaItemValidacao(), InicializaServiceItem());
        }

        private IRepositoryComandaItem InicializaRepositoryComandaItem()
        {
            var mock = new Mock<IRepositoryComandaItem>();
            mock.Setup(m => m.GetAll()).Returns(ComandaItemFaker.GetComandaItemsAsQueryable());
            return mock.Object;
        }

        private IServiceComandaItemValidacao InicializaServiceComandaItemValidacao()
        {
            var service = new ServiceComandaItemValidacao(InicializaRepositoryComandaItem(), InicializaServiceComanda(), InicializaServiceItem());
            return service;
        }

        private IServiceComanda InicializaServiceComanda()
        {
            var service = new ServiceComanda(InicializaRepositoryComanda());
            return service;
        }

        private IServiceItem InicializaServiceItem()
        {
            var service = new ServiceItem(InicializaRepositoryItem());
            return service;
        }

        private IRepositoryComanda InicializaRepositoryComanda()
        {
            var mock = new Mock<IRepositoryComanda>();
            mock.Setup(m => m.GetById(It.IsAny<int>())).Returns((int id) => GetComandaById(id));

            return mock.Object;
        }

        private Entities.Comanda GetComandaById(int id)
        {
            var Comanda = ComandaFaker.GetComandasAsQueryable().ToList().FirstOrDefault(x => x.Id == id);
            return Comanda;
        }

        private IRepositoryItem InicializaRepositoryItem()
        {
            var mock = new Mock<IRepositoryItem>();
            mock.Setup(m => m.GetById(It.IsAny<int>())).Returns((int id) => GetItemById(id));
            return mock.Object;
        }

        private Entities.Item GetItemById(int id)
        {
            var item = ItemFaker.GetItemsAsQueryable().ToList().FirstOrDefault(x => x.Id == id);
            return item;
        }
    }
}