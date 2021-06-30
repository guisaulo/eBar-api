using eBar.Application.Dtos;

namespace eBar.Application.Interfaces
{
    public interface IApplicationServiceComandaItem
    {
        void InserirItemComanda(ComandaItemDto comandaItemDto);

        void ResetarComanda(int comandaId);

        NotaFiscalComandaDto GerarNotaFiscalComanda(int comandaId);
    }
}