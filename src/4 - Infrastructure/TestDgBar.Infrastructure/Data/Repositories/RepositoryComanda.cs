using TestDgBar.Domain.Core.Interfaces.Repositories;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Infrastructure.Data.Repositories
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