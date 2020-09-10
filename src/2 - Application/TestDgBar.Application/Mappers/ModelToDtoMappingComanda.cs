using AutoMapper;
using TestDgBar.Application.Dtos;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Application.Mappers
{
    public class ModelToDtoMappingComanda : Profile
    {
        public ModelToDtoMappingComanda()
        {
            ComandaDtoMap();
        }

        private void ComandaDtoMap()
        {
            CreateMap<Comanda, ComandaDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome));
        }
    }
}