using Microsoft.EntityFrameworkCore;
using TestDgBar.Domain.Entities;

namespace TestDgBar.Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<Comanda> Comanda { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ComandaItem> ComandaItem { get; set; }
    }
}