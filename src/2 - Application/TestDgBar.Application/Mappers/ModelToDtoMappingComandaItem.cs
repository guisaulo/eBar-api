using AutoMapper;
using TestDgBar.Application.Dtos;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Application.Mappers
{
    public class ModelToDtoMappingComandaItem : Profile
    {
        public ModelToDtoMappingComandaItem()
        {
            ComandaItemDtoMap();
        }

        private void ComandaItemDtoMap()
        {
            CreateMap<ComandaItem, ComandaItemDto>()
                .ForMember(dest => dest.ComandaId, opt => opt.MapFrom(x => x.ComandaId))
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(x => x.ItemId));
        }
    }
}