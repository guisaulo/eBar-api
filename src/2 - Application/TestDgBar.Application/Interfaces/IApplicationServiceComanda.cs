using System.Collections.Generic;
using TestDgBar.Application.Dtos;

namespace TestDgBar.Application.Interfaces
{
    public interface IApplicationServiceComanda
    {
        void Add(ComandaDto ComandaDto);

        void Update(ComandaDto ComandaDto);

        void Remove(ComandaDto ComandaDto);

        IEnumerable<ComandaDto> GetAll();

        ComandaDto GetById(int id);
    }
}