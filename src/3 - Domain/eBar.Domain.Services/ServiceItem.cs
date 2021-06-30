using eBar.Domain.Core.Interfaces.Repositories;
using eBar.Domain.Core.Interfaces.Services;
using eBar.Domain.Entities;

namespace eBar.Domain.Services
{
    public class ServiceItem : ServiceBase<Item>, IServiceItem
    {
        private readonly IRepositoryItem repositoryItem;

        public ServiceItem(IRepositoryItem repositoryItem)
            : base(repositoryItem)
        {
            this.repositoryItem = repositoryItem;
        }

        public Item ObterItem(int itemId)
        {
            return repositoryItem.GetById(itemId);
        }
    }
}