using AutoMapper;
using System.Collections.Generic;
using TestDgBar.Application.Dtos;
using TestDgBar.Application.Interfaces;
using TestDgBar.Domain.Core.Interfaces.Services;

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
        public IEnumerable<ItemDto> GetAll()
        {
            var items = serviceItem.GetAll();
            var itemsDto = mapper.Map<IEnumerable<ItemDto>>(items);

            return itemsDto;
        }
    }
}