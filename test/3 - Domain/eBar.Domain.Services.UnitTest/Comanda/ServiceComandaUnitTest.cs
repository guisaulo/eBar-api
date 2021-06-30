using System.Linq;
using eBar.Domain.Services.UnitTest.Comanda.Fixture;
using Xunit;

namespace eBar.Domain.Services.UnitTest.Comanda
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

        [Fact]
        public void Deve_Executar_Consulta_ObterComanda_Com_Sucesso()
        {
            var result = _serviceComanda.GetById(1);
            Assert.True(result.Id.Equals(1));
            Assert.True(result.Nome.Equals("Comanda 1"));
        }
    }
}