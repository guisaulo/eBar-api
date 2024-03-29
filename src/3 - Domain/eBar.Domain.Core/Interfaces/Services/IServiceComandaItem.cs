﻿using eBar.Domain.Entities;

namespace eBar.Domain.Core.Interfaces.Services
{
    public interface IServiceComandaItem : IServiceBase<ComandaItem>
    {
        void InserirItemComanda(ComandaItem comandaItem);

        void ResetarComanda(int comandaId);

        NotaFiscalComanda GerarNotaFiscalComanda(int comandaId);
    }
}