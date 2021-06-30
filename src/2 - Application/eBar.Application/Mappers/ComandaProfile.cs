using AutoMapper;
using eBar.Application.Dtos;
using eBar.Domain.Entities;

namespace eBar.Application.Mappers
{
    public class ComandaProfile : Profile
    {
        public ComandaProfile()
        {
            ComandaMap();
            ComandaDtoMap();
        }

        private void ComandaMap()
        {
            CreateMap<ComandaDto, Comanda>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome));
        }

        private void ComandaDtoMap()
        {
            CreateMap<Comanda, ComandaDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome));
        }
    }
}