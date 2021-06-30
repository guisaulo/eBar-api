using System.Collections.Generic;
using System.Linq;

namespace eBar.Domain.Services.UnitTest.Item.Faker
{
    public static class ItemFaker
    {
        public static IQueryable<Entities.Item> GetItemsAsQueryable() =>
            new List<Entities.Item>
            {
                GetItem(1, "Cerveja", 5),
                GetItem(2, "Conhaque", 20),
                GetItem(3, "Suco", 50),
                GetItem(4, "Água", 70)
            }.AsQueryable();

        private static Entities.Item GetItem(int id, string nome = "", decimal valor = 0) =>
            new Entities.Item()
            {
                Id = id,
                Nome = nome,
                Valor = valor
            };
    }
}