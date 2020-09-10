using TestDgBar.Domain.Core.Interfaces.Repositories;
using TestDgBar.Domain.Core.Interfaces.Services;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Domain.Services
{
    public class ServiceComandaItem : ServiceBase<ComandaItem>, IServiceComandaItem
    {
        private readonly IRepositoryComandaItem repositoryComandaItem;

        public ServiceComandaItem(IRepositoryComandaItem repositoryComandaItem)
            : base(repositoryComandaItem)
        {
            this.repositoryComandaItem = repositoryComandaItem;
        }
    }
}