using TestDgBar.Domain.Entities;

namespace TestDgBar.Domain.Core.Interfaces.Services
{
    public interface IServiceComanda : IServiceBase<Comanda>
    {
        Comanda ObterComanda(int comandaId);
    }
}
