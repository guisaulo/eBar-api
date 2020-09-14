using System;
using System.Collections.Generic;
using System.Linq;
using TestDgBar.Domain.Core.Interfaces.Repositories;
using TestDgBar.Domain.Core.Interfaces.Services;
using TestDgBar.Domain.Entities;
using TestDgBar.Domain.Services.Constants;

namespace TestDgBar.Domain.Services
{
    public class ServiceComandaItem : ServiceBase<ComandaItem>, IServiceComandaItem
    {
        private readonly IRepositoryComandaItem repositoryComandaItem;
        private readonly IServiceComandaItemValidacao serviceComandaItemValidacao;
        private readonly IServiceItem serviceItem;

        public ServiceComandaItem(
            IRepositoryComandaItem repositoryComandaItem,
            IServiceComandaItemValidacao serviceComandaItemValidacao,
            IServiceItem serviceItem)
            : base(repositoryComandaItem)
        {
            this.repositoryComandaItem = repositoryComandaItem;
            this.serviceComandaItemValidacao = serviceComandaItemValidacao;
            this.serviceItem = serviceItem;
        }

        public void InserirItemComanda(ComandaItem comandaItem)
        {
            serviceComandaItemValidacao.ValidarInserirComandaItem(comandaItem);
            repositoryComandaItem.Add(comandaItem);                
        }

        public void ResetarComanda(int comandaId)
        {
            serviceComandaItemValidacao.ValidarSeComandaExiste(comandaId);
            var comandaItens = repositoryComandaItem.GetAll().Where(c => c.ComandaId == comandaId).ToList();
            foreach (var item in comandaItens)            
                repositoryComandaItem.Remove(item);            
        }

        public NotaFiscalComanda GerarNotaFiscalComanda(int comandaId)
        {
            serviceComandaItemValidacao.ValidarSeComandaExiste(comandaId);
            var comandaItens = repositoryComandaItem.GetAll().Where(c => c.ComandaId == comandaId).ToList();
            var itens = ObterItens(comandaItens);
            var desconto = ObterDesconto(comandaItens);
            var valorTotal = ObterValorTotal(itens, desconto);
            return new NotaFiscalComanda
            {
                Items = itens,
                Desconto = desconto,
                ValorTotal = valorTotal
            };
        }

        private List<Item> ObterItens(List<ComandaItem> comandaItens)
        {
            var itens = new List<Item>();
            foreach (var comandaItem in comandaItens)
                itens.Add(serviceItem.ObterItem(comandaItem.ItemId));
            return itens;
        }

        private decimal ObterDesconto(List<ComandaItem> comandaItens)
        {
            var desconto = ObterDescontoCerveja(comandaItens);
            desconto += ObterDescontoAgua(comandaItens);
            return desconto;
        }

        private decimal ObterDescontoCerveja(List<ComandaItem> comandaItens)
        {
            var descontoCerveja = 0;
            var numCervejas = comandaItens.Where(x => x.ItemId == ItemConstants.Cerveja).Count();
            var numSucos = comandaItens.Where(x => x.ItemId == ItemConstants.Suco).Count();
            if (numCervejas >= 1 && numSucos >= 1)
                descontoCerveja += Math.Min(numCervejas, numSucos) * 2;            
            return descontoCerveja;
        }

        private decimal ObterDescontoAgua(List<ComandaItem> comandaItens)
        {
            var descontoAgua = 0;
            var numAgua= comandaItens.Where(x => x.ItemId == ItemConstants.Agua).Count();
            if (numAgua == 0)
                return descontoAgua;

            var numConhaques = comandaItens.Where(x => x.ItemId == ItemConstants.Conhaque).Count();
            var numCervejas = comandaItens.Where(x => x.ItemId == ItemConstants.Cerveja).Count();
            var qtdPermitidaDesconto = ObterQuantidadePermitidaDescontoAgua(numConhaques, numCervejas);
            var qtdAguaDesconto = Math.Min(numAgua, qtdPermitidaDesconto);
            return qtdAguaDesconto * 70;
        }

        private int ObterQuantidadePermitidaDescontoAgua(int numConhaques, int numCervejas)
        {
            if (numConhaques >= 3 && numCervejas >= 2)
            {
                var qtdConhaques = numConhaques / 3;
                var qtdCervejas = numCervejas / 2;
                return Math.Min(qtdConhaques, qtdCervejas);
            }
            return 0;
        }

        private decimal ObterValorTotal(List<Item> itens, decimal desconto)
        {
            var total = itens.Sum(x => x.Valor);
            return total - desconto;
        }
    }
}