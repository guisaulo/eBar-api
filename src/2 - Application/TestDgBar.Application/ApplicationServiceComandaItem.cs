using AutoMapper;
using System.Collections.Generic;
using TestDgBar.Application.Dtos;
using TestDgBar.Application.Interfaces;
using TestDgBar.Domain.Core.Interfaces.Services;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Application
{
    public class ApplicationServiceComandaItem : IApplicationServiceComandaItem
    {
        private readonly IServiceComandaItem serviceComandaItem;
        private readonly IMapper mapper;
        public ApplicationServiceComandaItem(IServiceComandaItem serviceComandaItem, IMapper mapper)
        {
            this.serviceComandaItem = serviceComandaItem;
            this.mapper = mapper;
        }

        public IEnumerable<ComandaItemDto> GetAll()
        {
            var comandaItems = serviceComandaItem.GetAll();
            var comandaItemsDto = mapper.Map<IEnumerable<ComandaItemDto>>(comandaItems);

            return comandaItemsDto;
        }

        public ComandaItemDto GetById(int id)
        {
            var comandaItem = serviceComandaItem.GetById(id);
            var comandaItemDto = mapper.Map<ComandaItemDto>(comandaItem);

            return comandaItemDto;
        }

        public void InserirItemComanda(ComandaItemDto comandaItemDto)
        {
            var comandaItem = mapper.Map<ComandaItem>(comandaItemDto);
            serviceComandaItem.InserirItemComanda(comandaItem);
        }

        public void ResetarComanda(int comandaId)
        {
            serviceComandaItem.ResetarComanda(comandaId);
        }

        public NotaFiscalComandaDto GerarNotaFiscalComanda(int comandaId)
        {
            var notaFiscalComanda = serviceComandaItem.GerarNotaFiscalComanda(comandaId);
            return mapper.Map<NotaFiscalComandaDto>(notaFiscalComanda);
        }
    }
}