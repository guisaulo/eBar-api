using System.Collections.Generic;
using TestDgBar.Application.Dtos;

namespace TestDgBar.Application.Interfaces
{
    public interface IApplicationServiceItem
    {
        IEnumerable<ItemDto> GetAll();
    }
}