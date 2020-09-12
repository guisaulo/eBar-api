using TestDgBar.Application.Dtos;

namespace TestDgBar.Application.Interfaces
{
    public interface IApplicationServiceComandaItem
    {
        void InserirItemComanda(ComandaItemDto comandaItemDto);

        void ResetarComanda(int comandaId);

        NotaFiscalComandaDto GerarNotaFiscalComanda(int comandaId);
    }
}