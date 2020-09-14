using System.Linq;
using TestDgBar.Application.UnitTest.Comanda.Fixture;
using Xunit;

namespace TestDgBar.Application.UnitTest.Comanda
{
    public class ApplicationServiceComandaUnitTest : IClassFixture<ComandaFixture>
    {
        private readonly ApplicationServiceComanda _applicationServiceComanda;
        public ApplicationServiceComandaUnitTest(ComandaFixture fixture)
        {
            _applicationServiceComanda = fixture.Service;
        }

        [Fact]
        public void Deve_Executar_Consulta_GetAll_E_Retorno_Esperado_Com_Sucesso()
        {
            var result = _applicationServiceComanda.GetAll().ToList();
            Assert.True(result.Count().Equals(1));
            Assert.True(result[0].Id.Equals(1));
            Assert.True(result[0].Nome.Equals("Comanda 1"));
        }
    }
}