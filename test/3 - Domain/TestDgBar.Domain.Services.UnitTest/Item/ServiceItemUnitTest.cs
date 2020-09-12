using System.Linq;
using TestDgBar.Domain.Services.UnitTest.Item.Fixture;
using Xunit;

namespace TestDgBar.Domain.Services.UnitTest.Item
{
    public class ServiceItemUnitTest : IClassFixture<ItemFixture>
    {
        private readonly ServiceItem _serviceItem;
        public ServiceItemUnitTest(ItemFixture fixture)
        {
            _serviceItem = fixture.Service;
        }

        [Fact]
        public void Deve_Executar_Consulta_GetAll_E_Retornar_Quantidade_Esperada()
        {
            var result = _serviceItem.GetAll();
            Assert.True(result.Count().Equals(4));
        }
    }
}