using eBar.Domain.Core.Interfaces.Repositories;
using eBar.Domain.Entities;

namespace eBar.Infrastructure.Data.Repositories
{
    public class RepositoryItem : RepositoryBase<Item>, IRepositoryItem
    {
        private readonly SqlContext sqlContext;

        public RepositoryItem(SqlContext sqlContext)
            : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}