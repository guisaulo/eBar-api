using System.Linq;
using TestDgBar.Application.UnitTest.Item.Fixture;
using Xunit;

namespace TestDgBar.Application.UnitTest.Item
{
    public class ApplicationServiceItemUnitTest : IClassFixture<ItemFixture>
    {
        private readonly ApplicationServiceItem _applicationServiceItem;
        public ApplicationServiceItemUnitTest(ItemFixture fixture)
        {
            _applicationServiceItem = fixture.Service;
        }

        [Fact]
        public void Deve_Executar_Consulta_GetAll_E_Retorno_Esperado_Com_Sucesso()
        {
            var result = _applicationServiceItem.GetAll().ToList();
            Assert.True(result.Count().Equals(1));
            Assert.True(result[0].Id.Equals(1));
            Assert.True(result[0].Nome.Equals("Cerveja"));
            Assert.True(result[0].Valor.Equals(5));
        }
    }
}