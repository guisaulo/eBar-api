using TestDgBar.Domain.Core.Interfaces.Repositories;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Infrastructure.Data.Repositories
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