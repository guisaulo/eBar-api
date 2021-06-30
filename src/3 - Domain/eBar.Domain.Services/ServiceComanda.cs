using eBar.Domain.Core.Interfaces.Repositories;
using eBar.Domain.Core.Interfaces.Services;
using eBar.Domain.Entities;

namespace eBar.Domain.Services
{
    public class ServiceComanda : ServiceBase<Comanda>, IServiceComanda
    {
        private readonly IRepositoryComanda repositoryComanda;

        public ServiceComanda(IRepositoryComanda repositoryComanda)
            : base(repositoryComanda)
        {
            this.repositoryComanda = repositoryComanda;
        }

        public Comanda ObterComanda(int comandaId)
        {
            return repositoryComanda.GetById(comandaId);
        }
    }
}