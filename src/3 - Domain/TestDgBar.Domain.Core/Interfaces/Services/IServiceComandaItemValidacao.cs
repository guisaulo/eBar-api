using TestDgBar.Domain.Entities;

namespace TestDgBar.Domain.Core.Interfaces.Services
{
    public interface IServiceComandaItemValidacao
    {
        void ValidarInserirComandaItem(ComandaItem comandaItem);
        void ValidarSeComandaExiste(int comandaId);
    }
}