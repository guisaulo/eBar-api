using TestDgBar.Domain.Core.Interfaces.Repositories;
using TestDgBar.Domain.Core.Interfaces.Services;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Domain.Services
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