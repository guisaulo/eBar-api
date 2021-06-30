using eBar.Domain.Entities;

namespace eBar.Domain.Core.Interfaces.Services
{
    public interface IServiceItem : IServiceBase<Item>
    {
        Item ObterItem(int itemId);
    }
}
