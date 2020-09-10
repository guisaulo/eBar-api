using System.Collections.Generic;
using TestDgBar.Application.Dtos;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Application.Interfaces
{
    public interface IApplicationServiceComandaItem
    {
        IEnumerable<ComandaItemDto> GetAll();

        ComandaItemDto GetById(int id);

        void InserirItemComanda(ComandaItemDto comandaItemDto);

        void ResetarComanda(int comandaId);

        NotaFiscalComandaDto GerarNotaFiscalComanda(int comandaId);
    }
}