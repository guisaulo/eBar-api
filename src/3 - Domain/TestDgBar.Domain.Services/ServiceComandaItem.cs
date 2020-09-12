﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TestDgBar.Domain.Core.Interfaces.Repositories;
using TestDgBar.Domain.Core.Interfaces.Services;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Domain.Services
{
    public class ServiceComandaItem : ServiceBase<ComandaItem>, IServiceComandaItem
    {
        private readonly IRepositoryComandaItem repositoryComandaItem;
        private readonly IRepositoryItem repositoryItem;
        private readonly IRepositoryComanda repositoryComanda;
        private const int CervejaId = 1;
        private const int ConhaqueId = 2;
        private const int SucoId = 3;
        private const int AguaId = 4;

        public ServiceComandaItem(IRepositoryComandaItem repositoryComandaItem, IRepositoryItem repositoryItem, IRepositoryComanda repositoryComanda)
            : base(repositoryComandaItem)
        {
            this.repositoryComandaItem = repositoryComandaItem;
            this.repositoryItem = repositoryItem;
            this.repositoryComanda = repositoryComanda;
        }

        public void InserirItemComanda(ComandaItem comandaItem)
        {
            ValidarQuantidadeSucosComanda(comandaItem);
            repositoryComandaItem.Add(comandaItem);                
        }

        private void ValidarQuantidadeSucosComanda(ComandaItem comandaItem)
        {
            var quantidadeSucosComanda = repositoryComandaItem.GetAll().Where(c => c.ComandaId == comandaItem.ComandaId && c.ItemId == SucoId).Count();
            if (comandaItem.ItemId == SucoId && quantidadeSucosComanda >= 3)
                throw new ValidationException("Só é permitido 3 sucos por comanda");
        }

        public void ResetarComanda(int comandaId)
        {
            ValidarSeComandaExiste(comandaId);
            var comandaItens = repositoryComandaItem.GetAll().Where(c => c.ComandaId == comandaId).ToList();
            foreach (var item in comandaItens)            
                repositoryComandaItem.Remove(item);            
        }

        private void ValidarSeComandaExiste(int comandaId)
        {
            var comanda = repositoryComanda.GetById(comandaId);
            if (comanda == default)
                throw new ValidationException("Comanda não existe");
        }

        public NotaFiscalComanda GerarNotaFiscalComanda(int comandaId)
        {
            ValidarSeComandaExiste(comandaId);
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
                itens.Add(repositoryItem.GetById(comandaItem.ItemId));
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
            var numCervejas = comandaItens.Where(x => x.ItemId == CervejaId).Count();
            var numSucos = comandaItens.Where(x => x.ItemId == SucoId).Count();

            if (numCervejas >= 1 && numSucos >= 1)
                descontoCerveja += Math.Min(numCervejas, numSucos) * 2;
            
            return descontoCerveja;
        }

        private decimal ObterDescontoAgua(List<ComandaItem> comandaItens)
        {
            var descontoAgua = 0;
            var numAgua= comandaItens.Where(x => x.ItemId == AguaId).Count();
            if (numAgua == 0)
                return descontoAgua;

            var numConhaques = comandaItens.Where(x => x.ItemId == ConhaqueId).Count();
            var numCervejas = comandaItens.Where(x => x.ItemId == CervejaId).Count();

            var qtdPermitidaDesconto = ObterQuantidadePermitidaDescontoAgua(numConhaques, numCervejas);
            var qtdAguaDesconto = Math.Min(numAgua, qtdPermitidaDesconto);

            return qtdAguaDesconto * 70;
        }

        private int ObterQuantidadePermitidaDescontoAgua(int numConhaques, int numCervejas)
        {
            if (numConhaques >= 3 && numCervejas >= 2)
            {
                var co = numConhaques / 3;
                var ce = numCervejas / 2;

                return Math.Min(co, ce);
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