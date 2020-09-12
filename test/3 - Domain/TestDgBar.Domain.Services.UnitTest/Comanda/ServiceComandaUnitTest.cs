using System.Linq;
using TestDgBar.Domain.Services.UnitTest.Comanda.Fixture;
using Xunit;

namespace TestDgBar.Domain.Services.UnitTest.Comanda
{
    public class ServiceComandaUnitTest : IClassFixture<ComandaFixture>
    {
        private readonly ServiceComanda _serviceComanda;
        public ServiceComandaUnitTest(ComandaFixture fixture)
        {
            _serviceComanda = fixture.Service;
        }

        [Fact]
        public void Deve_Executar_Consulta_GetAll_E_Retornar_Quantidade_Esperada()
        {
            var result = _serviceComanda.GetAll();
            Assert.True(result.Count().Equals(5));
        }
    }
}