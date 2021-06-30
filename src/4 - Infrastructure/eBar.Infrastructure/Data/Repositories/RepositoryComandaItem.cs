using eBar.Domain.Core.Interfaces.Repositories;
using eBar.Domain.Entities;

namespace eBar.Infrastructure.Data.Repositories
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