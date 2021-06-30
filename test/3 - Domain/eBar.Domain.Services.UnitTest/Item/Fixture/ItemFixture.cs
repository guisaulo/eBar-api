using Moq;
using System.Linq;
using eBar.Domain.Core.Interfaces.Repositories;
using eBar.Domain.Services.UnitTest.Item.Faker;

namespace eBar.Domain.Services.UnitTest.Item.Fixture
{
    public class ItemFixture
    {
        public readonly ServiceItem Service;

        public ItemFixture()
        {
            Service = new ServiceItem(InicializaRepositoryItem());
        }

        private IRepositoryItem InicializaRepositoryItem()
        {
            var mock = new Mock<IRepositoryItem>();
            mock.Setup(m => m.GetAll()).Returns(ItemFaker.GetItemsAsQueryable());
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