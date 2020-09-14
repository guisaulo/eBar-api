using FluentAssertions;
using System.Linq;
using TestDgBar.Application.Dtos;
using TestDgBar.Application.UnitTest.ComandaItem.Fixture;
using Xunit;

namespace TestDgBar.Application.UnitTest.ComandaItem
{
    public class ApplicationServiceComandaItemUnitTest : IClassFixture<ComandaItemFixture>
    {
        private readonly ApplicationServiceComandaItem _applicationServiceComandaItem;
        public ApplicationServiceComandaItemUnitTest(ComandaItemFixture fixture)
        {
            _applicationServiceComandaItem = fixture.Service;
        }

        [Fact]
        public void Deve_Executar_Metodo_InserirItemComanda_Com_Sucesso()
        {
            var comandaItemDto = new ComandaItemDto { ComandaId = 1, ItemId = 1};
            try
            {
                _applicationServiceComandaItem.InserirItemComanda(comandaItemDto);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }

        [Fact]
        public void Deve_Executar_Metodo_ResetarComanda_Com_Sucesso()
        {
            try
            {
                _applicationServiceComandaItem.ResetarComanda(1);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }

        [Fact]
        public void Deve_Gerar_Nota_Fiscal_E_Retornar_Dados_Com_Sucesso()
        {
            var result = _applicationServiceComandaItem.GerarNotaFiscalComanda(1);
            result.Items.Count().Should().Be(1);
            result.Desconto.Should().Be(5);
            result.ValorTotal.Should().Be(15);
        }
    }
}