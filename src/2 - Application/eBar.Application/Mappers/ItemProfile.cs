﻿using AutoMapper;
using eBar.Application.Dtos;
using eBar.Domain.Entities;

namespace eBar.Application.Mappers
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            ItemMap();
            ItemDtoMap();
        }

        private void ItemMap()
        {
            CreateMap<ItemDto, Item>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(x => x.Valor));
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