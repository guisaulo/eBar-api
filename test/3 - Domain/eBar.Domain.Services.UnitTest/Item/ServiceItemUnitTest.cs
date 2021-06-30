using System.Linq;
using eBar.Domain.Services.UnitTest.Item.Fixture;
using Xunit;

namespace eBar.Domain.Services.UnitTest.Item
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

        [Fact]
        public void Deve_Executar_Consulta_ObterItem_Com_Sucesso()
        {
            var result = _serviceItem.GetById(1);
            Assert.True(result.Id.Equals(1));
            Assert.True(result.Nome.Equals("Cerveja"));
            Assert.True(result.Valor.Equals(5));
        }
    }
}