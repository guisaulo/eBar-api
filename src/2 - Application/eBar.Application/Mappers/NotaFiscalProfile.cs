using AutoMapper;
using eBar.Application.Dtos;
using eBar.Domain.Entities;

namespace eBar.Application.Mappers
{
    public class NotaFiscalProfile : Profile
    {
        public NotaFiscalProfile()
        {
            NotaFiscalComandaMap();
        }

        private void NotaFiscalComandaMap()
        {
            CreateMap<NotaFiscalComanda, NotaFiscalComandaDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(x => x.Items))
                .ForMember(dest => dest.Desconto, opt => opt.MapFrom(x => x.Desconto))
                .ForMember(dest => dest.ValorTotal, opt => opt.MapFrom(x => x.ValorTotal));
        }
    }
}