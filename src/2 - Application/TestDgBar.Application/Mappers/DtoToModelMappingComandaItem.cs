using AutoMapper;
using TestDgBar.Application.Dtos;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Application.Mappers
{
    public class DtoToModelMappingComandaItem : Profile
    {
        public DtoToModelMappingComandaItem()
        {
            ComandaMap();
        }

        private void ComandaMap()
        {
            CreateMap<ComandaItemDto, ComandaItem>()
                .ForMember(dest => dest.ComandaId, opt => opt.MapFrom(x => x.ComandaId))
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(x => x.ItemId));

        }
    }
}