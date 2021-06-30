using AutoMapper;
using System.Collections.Generic;
using eBar.Application.Dtos;
using eBar.Application.Interfaces;
using eBar.Domain.Core.Interfaces.Services;

namespace eBar.Application
{
    public class ApplicationServiceComanda : IApplicationServiceComanda
    {
        private readonly IServiceComanda serviceComanda;
        private readonly IMapper mapper;
        public ApplicationServiceComanda(IServiceComanda serviceComanda, IMapper mapper)
        {
            this.serviceComanda = serviceComanda;
            this.mapper = mapper;
        }

        public IEnumerable<ComandaDto> GetAll()
        {
            var comandas = serviceComanda.GetAll();
            var comandasDto = mapper.Map<IEnumerable<ComandaDto>>(comandas);
            return comandasDto;
        }
    }
}