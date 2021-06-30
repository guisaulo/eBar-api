using AutoMapper;
using eBar.Application.Dtos;
using eBar.Application.Interfaces;
using eBar.Domain.Core.Interfaces.Services;
using eBar.Domain.Entities;

namespace eBar.Application
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