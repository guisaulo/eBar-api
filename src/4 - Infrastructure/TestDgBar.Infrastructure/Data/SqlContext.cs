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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComandaItem>(entity =>
            {
                entity.HasKey(e => new { e.ComandaId, e.ItemId });

                entity.HasOne(d => d.Comanda)
                    .WithMany(p => p.ComandaItem)
                    .HasForeignKey(d => d.ComandaId);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ComandaItem)
                    .HasForeignKey(d => d.ItemId);
            });
        }

        public DbSet<Comanda> Comanda { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ComandaItem> ComandaItem { get; set; }
    }
}