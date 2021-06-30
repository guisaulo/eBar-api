using eBar.Domain.Entities;

namespace eBar.Domain.Core.Interfaces.Services
{
    public interface IServiceComandaItemValidacao
    {
        void ValidarInserirComandaItem(ComandaItem comandaItem);
        void ValidarSeComandaExiste(int comandaId);
    }
}