using eBar.Domain.Core.Interfaces.Repositories;
using eBar.Domain.Entities;

namespace eBar.Infrastructure.Data.Repositories
{
    public class RepositoryComanda : RepositoryBase<Comanda>, IRepositoryComanda
    {
        private readonly SqlContext sqlContext;

        public RepositoryComanda(SqlContext sqlContext)
            : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}