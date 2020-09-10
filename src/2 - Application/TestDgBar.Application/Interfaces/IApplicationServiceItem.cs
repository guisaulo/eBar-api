using System.Collections.Generic;
using TestDgBar.Application.Dtos;

namespace TestDgBar.Application.Interfaces
{
    public interface IApplicationServiceItem
    {
        void Add(ItemDto ItemDto);

        void Update(ItemDto ItemDto);

        void Remove(ItemDto ItemDto);

        IEnumerable<ItemDto> GetAll();

        ItemDto GetById(int id);
    }
}