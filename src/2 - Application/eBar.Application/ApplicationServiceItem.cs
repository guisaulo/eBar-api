using AutoMapper;
using System.Collections.Generic;
using eBar.Application.Dtos;
using eBar.Application.Interfaces;
using eBar.Domain.Core.Interfaces.Services;

namespace eBar.Application
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
        public IEnumerable<ItemDto> GetAll()
        {
            var items = serviceItem.GetAll();
            var itemsDto = mapper.Map<IEnumerable<ItemDto>>(items);
            return itemsDto;
        }
    }
}