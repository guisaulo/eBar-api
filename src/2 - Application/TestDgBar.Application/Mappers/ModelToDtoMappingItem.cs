using AutoMapper;
using TestDgBar.Application.Dtos;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Application.Mappers
{
    public class ModelToDtoMappingItem : Profile
    {
        public ModelToDtoMappingItem()
        {
            ItemDtoMap();
        }

        private void ItemDtoMap()
        {
            CreateMap<Item, ItemDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(x => x.Valor));
        }
    }
}