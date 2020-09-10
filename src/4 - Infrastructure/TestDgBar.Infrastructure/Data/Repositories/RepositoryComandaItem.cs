using TestDgBar.Domain.Core.Interfaces.Repositories;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Infrastructure.Data.Repositories
{
    public class RepositoryComandaItem : RepositoryBase<ComandaItem>, IRepositoryComandaItem
    {
        private readonly SqlContext sqlContext;

        public RepositoryComandaItem(SqlContext sqlContext)
            : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}