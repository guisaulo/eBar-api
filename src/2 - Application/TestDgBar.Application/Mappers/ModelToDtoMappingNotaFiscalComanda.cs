using AutoMapper;
using TestDgBar.Application.Dtos;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Application.Mappers
{
    public class ModelToDtoMappingNotaFiscalComanda : Profile
    {
        public ModelToDtoMappingNotaFiscalComanda()
        {
            ItemDtoMap();
        }

        private void ItemDtoMap()
        {
            CreateMap<NotaFiscalComanda, NotaFiscalComandaDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(x => x.Items))
                .ForMember(dest => dest.Desconto, opt => opt.MapFrom(x => x.Desconto))
                .ForMember(dest => dest.ValorTotal, opt => opt.MapFrom(x => x.ValorTotal));
        }
    }
}