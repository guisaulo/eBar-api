using FluentAssertions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using eBar.Domain.Services.UnitTest.ComandaItemItem.Fixture;
using Xunit;

namespace eBar.Domain.Services.UnitTest.ComandaItem
{
    public class ServiceComandaItemUnitTest : IClassFixture<ComandaItemFixture>
    {
        private readonly ServiceComandaItem _serviceComandaItem;
        public ServiceComandaItemUnitTest(ComandaItemFixture fixture)
        {
            _serviceComandaItem = fixture.Service;
        }

        [Fact]
        public void Quando_Inserir_Item_Em_Comanda_Com_Item_Inexistente_Deve_Lancar_ValidationException()
        {
            var comandaItem = new Entities.ComandaItem() { ItemId = 999, ComandaId = 1 };
            Assert.Throws<ValidationException>(() => { _serviceComandaItem.InserirItemComanda(comandaItem); })
                .Message.Should().Be(Properties.Resources.ItemNaoExiste);
        }

        [Fact]
        public void Quando_Inserir_Item_Em_Comanda_Com_Comanda_Inexistente_Deve_Lancar_ValidationException()
        {
            var comandaItem = new Entities.ComandaItem() { ItemId = 1, ComandaId = 999 };
            Assert.Throws<ValidationException>(() => { _serviceComandaItem.InserirItemComanda(comandaItem); })
                .Message.Should().Be(Properties.Resources.ComandaNaoExiste); ;
        }

        [Fact]
        public void Quando_Inserir_Item_Em_Comanda_Com_3_Sucos_Deve_Lancar_ValidationException()
        {
            var comandaItem = new Entities.ComandaItem() { ItemId = 3, ComandaId = 1 };
            Assert.Throws<ValidationException>(() => { _serviceComandaItem.InserirItemComanda(comandaItem); })
                .Message.Should().Be(Properties.Resources.QuantidadeSucosPermitida);
        }

        [Fact]
        public void Deve_Inserir_Item_Comanda_Com_Sucesso()
        {
            var comandaItem = new Entities.ComandaItem() { ItemId = 1, ComandaId = 1 };
            try
            {
                _serviceComandaItem.InserirItemComanda(comandaItem);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }

        [Fact]
        public void Quando_Resetar_Comanda_Que_Nao_Existe_Deve_Lancar_ValidationException()
        {
            var comanda = new Entities.Comanda() { Id = 99 };
            Assert.Throws<ValidationException>(() => { _serviceComandaItem.ResetarComanda(comanda.Id); })
                .Message.Should().Be(Properties.Resources.ComandaNaoExiste);
        }

        [Fact]
        public void Deve_Resetar_Comanda_Com_Sucesso()
        {
            try
            {
                _serviceComandaItem.ResetarComanda(1);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Quando_Gerar_Nota_Fiscal_De_Comanda_Que_Nao_Existe_Deve_Lancar_ValidationException()
        {
            var comanda = new Entities.Comanda() { Id = 99 };
            Assert.Throws<ValidationException>(() => { _serviceComandaItem.GerarNotaFiscalComanda(comanda.Id); })
                .Message.Should().Be(Properties.Resources.ComandaNaoExiste);
        }

        [Theory]
        [MemberData(nameof(GetCenariosDescontoNotaFiscal))]
        public void Deve_Gerar_Nota_Fiscal_Com_Items_Desconto_E_Valor_Total_Esperados(int comandaId, int qtdItemsEsperados, decimal descontoEsperado, decimal valorTotalEsperado)
        {
            var result = _serviceComandaItem.GerarNotaFiscalComanda(comandaId);
            result.Items.Count().Should().Be(qtdItemsEsperados);
            result.Desconto.Should().Be(descontoEsperado);
            result.ValorTotal.Should().Be(valorTotalEsperado);
        }

        public static IEnumerable<object[]> GetCenariosDescontoNotaFiscal()
        {
            var allData = new List<object[]>
            {
                //Cenário 1 - Deve_Gerar_Nota_Fiscal_Com_Sucesso_E_Retornar_Valores_Resperados
                new object[] {1, 3, 0, 150},
                //Cenário 2 - Quando_Gerar_Nota_Fiscal_Com_Comanda_Com_1_Cerveja_E_1_Suco_Retornar_Desconto_2_Reais_Cerveja
                new object[] {2, 2, 2, 53},
                //Cenário 3 - Quando_Gerar_Nota_Fiscal_Com_Comanda_Com_3_Conhaques_E_2_Cervejas_E_Agua_Deve_Retornar_Desconto_70_Reais_Da_Agua
                new object[] {3, 6, 70, 70},
                //Cenário 4 - Quando_Gerar_Nota_Fiscal_Com_Comanda_Com_3_Conhaques_E_2_Cervejas_E_Sem_Agua_Deve_Retornar_Desconto_70_Reais_Da_Agua
                new object[] {4, 5, 0, 70},
                //Cenário 5 - Quando_Gerar_Nota_Fiscal_Com_Sucesso_E_Retornar_Desconto_Cumulativo_Esperado
                new object[] {5, 7, 72, 118}
            };
            return allData;
        }
    }
}