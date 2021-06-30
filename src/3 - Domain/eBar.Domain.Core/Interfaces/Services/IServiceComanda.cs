using eBar.Domain.Entities;

namespace eBar.Domain.Core.Interfaces.Services
{
    public interface IServiceComanda : IServiceBase<Comanda>
    {
        Comanda ObterComanda(int comandaId);
    }
}
