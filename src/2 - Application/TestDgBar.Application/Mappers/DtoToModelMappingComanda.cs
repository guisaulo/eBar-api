using AutoMapper;
using TestDgBar.Application.Dtos;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Application.Mappers
{
    public class DtoToModelMappingComanda : Profile
    {
        public DtoToModelMappingComanda()
        {
            ComandaMap();
        }

        private void ComandaMap()
        {
            CreateMap<ComandaDto, Comanda>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome));
        }
    }
}