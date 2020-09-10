using AutoMapper;
using System.Collections.Generic;
using TestDgBar.Application.Dtos;
using TestDgBar.Application.Interfaces;
using TestDgBar.Domain.Core.Interfaces.Services;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Application
{
    public class ApplicationServiceItem : IApplicationServiceItem
    {
        private readonly IServiceItem serviceItem;
        private readonly IMapper mapper;
        public ApplicationServiceItem(IServiceItem serviceItem, IMapper mapper)
        {
            this.serviceItem = serviceItem;
            this.mapper = mapper;
        }
        public void Add(ItemDto itemDto)
        {
            var item = mapper.Map<Item>(itemDto);
            serviceItem.Add(item);
        }

        public IEnumerable<ItemDto> GetAll()
        {
            var items = serviceItem.GetAll();
            var itemsDto = mapper.Map<IEnumerable<ItemDto>>(items);

            return itemsDto;
        }

        public ItemDto GetById(int id)
        {
            var item = serviceItem.GetById(id);
            var itemDto = mapper.Map<ItemDto>(item);

            return itemDto;
        }

        public void Remove(ItemDto itemDto)
        {
            var item = mapper.Map<Item>(itemDto);
            serviceItem.Remove(item);
        }

        public void Update(ItemDto itemDto)
        {
            var item = mapper.Map<Item>(itemDto);
            serviceItem.Update(item);
        }
    }
}