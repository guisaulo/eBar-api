using AutoMapper;
using System.Collections.Generic;
using TestDgBar.Application.Dtos;
using TestDgBar.Application.Interfaces;
using TestDgBar.Domain.Core.Interfaces.Services;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Application
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
        public void Add(ComandaDto comandaDto)
        {
            var comanda = mapper.Map<Comanda>(comandaDto);
            serviceComanda.Add(comanda);
        }

        public IEnumerable<ComandaDto> GetAll()
        {
            var comandas = serviceComanda.GetAll();
            var comandasDto = mapper.Map<IEnumerable<ComandaDto>>(comandas);

            return comandasDto;
        }

        public ComandaDto GetById(int id)
        {
            var comanda = serviceComanda.GetById(id);
            var comandaDto = mapper.Map<ComandaDto>(comanda);

            return comandaDto;
        }

        public void Remove(ComandaDto comandaDto)
        {
            var comanda = mapper.Map<Comanda>(comandaDto);
            serviceComanda.Remove(comanda);
        }

        public void Update(ComandaDto comandaDto)
        {
            var comanda = mapper.Map<Comanda>(comandaDto);
            serviceComanda.Update(comanda);
        }
    }
}