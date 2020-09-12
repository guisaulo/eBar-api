using System.Collections.Generic;
using System.Linq;

namespace TestDgBar.Domain.Services.UnitTest.ComandaItemItem.Faker
{
    public static class ComandaItemFaker
    {
        public static IQueryable<Entities.ComandaItem> GetComandaItemsAsQueryable() =>
            new List<Entities.ComandaItem>
            {
                GetComandaItem(1, 1, 3),
                GetComandaItem(2, 1, 3),
                GetComandaItem(3, 1, 3),

                GetComandaItem(4, 2, 1),
                GetComandaItem(5, 2, 3),

                GetComandaItem(6, 3, 2),
                GetComandaItem(7, 3, 2),
                GetComandaItem(8, 3, 2),
                GetComandaItem(9, 3, 1),
                GetComandaItem(10, 3, 1),
                GetComandaItem(11, 3, 4),

                GetComandaItem(12, 4, 2),
                GetComandaItem(13, 4, 2),
                GetComandaItem(14, 4, 2),
                GetComandaItem(15, 4, 1),
                GetComandaItem(16, 4, 1),

                GetComandaItem(17, 5, 1),
                GetComandaItem(18, 5, 3),
                GetComandaItem(19, 5, 2),
                GetComandaItem(20, 5, 2),
                GetComandaItem(21, 5, 2),
                GetComandaItem(22, 5, 1),
                GetComandaItem(22, 5, 4),
            }.AsQueryable();

        private static Entities.ComandaItem GetComandaItem(int id, int comandaId, int itemId) =>
            new Entities.ComandaItem()
            {
                Id = id,
                ComandaId = comandaId,
                ItemId = itemId,
            };
    }
}