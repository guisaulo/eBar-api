using AutoMapper;
using TestDgBar.Application.Dtos;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Application.Mappers
{
    public class DtoToModelMappingItem : Profile
    {
        public DtoToModelMappingItem()
        {
            ComandaMap();
        }

        private void ComandaMap()
        {
            CreateMap<ItemDto, Item>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(x => x.Valor));

        }
    }
}