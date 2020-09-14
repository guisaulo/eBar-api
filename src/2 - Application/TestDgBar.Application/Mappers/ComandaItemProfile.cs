using AutoMapper;
using TestDgBar.Application.Dtos;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Application.Mappers
{
    public class ComandaItemProfile : Profile
    {
        public ComandaItemProfile()
        {
            ComandaItemMap();
            ComandaItemDtoMap();
        }

        private void ComandaItemMap()
        {
            CreateMap<ComandaItemDto, ComandaItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ComandaId, opt => opt.MapFrom(x => x.ComandaId))
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(x => x.ItemId));
        }

        private void ComandaItemDtoMap()
        {
            CreateMap<ComandaItem, ComandaItemDto>()
                .ForMember(dest => dest.ComandaId, opt => opt.MapFrom(x => x.ComandaId))
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(x => x.ItemId));
        }
    }
}