using TestDgBar.Domain.Core.Interfaces.Repositories;
using TestDgBar.Domain.Core.Interfaces.Services;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Domain.Services
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