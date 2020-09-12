using Moq;
using TestDgBar.Domain.Core.Interfaces.Repositories;
using TestDgBar.Domain.Services.UnitTest.Item.Faker;

namespace TestDgBar.Domain.Services.UnitTest.Item.Fixture
{
    public class ItemFixture
    {
        public readonly ServiceItem Service;

        public ItemFixture()
        {
            Service = new ServiceItem(InicializaIRepositoryItem());
        }

        private IRepositoryItem InicializaIRepositoryItem()
        {
            var mock = new Mock<IRepositoryItem>();

            mock.Setup(m => m.GetAll()).Returns(ItemFaker.GetItemsAsQueryable());

            return mock.Object;
        }
    }
}