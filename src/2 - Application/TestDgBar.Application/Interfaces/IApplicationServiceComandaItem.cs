using System.Collections.Generic;
using TestDgBar.Application.Dtos;

namespace TestDgBar.Application.Interfaces
{
    public interface IApplicationServiceComandaItem
    {
        void Add(ComandaItemDto ComandaItemDto);

        void Update(ComandaItemDto ComandaItemDto);

        void Remove(ComandaItemDto ComandaItemDto);

        IEnumerable<ComandaItemDto> GetAll();

        ComandaItemDto GetById(int id);
    }
}