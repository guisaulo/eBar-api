using System.Collections.Generic;
using System.Linq;

namespace TestDgBar.Domain.Services.UnitTest.Comanda.Faker
{
    public static class ComandaFaker
    {
        public static IQueryable<Entities.Comanda> GetComandasAsQueryable() =>
            new List<Entities.Comanda>
            {
                GetComanda(1, "Comanda 1"),            
                GetComanda(2, "Comanda 2"),
                GetComanda(3, "Comanda 3"),
                GetComanda(4, "Comanda 4"),
                GetComanda(5, "Comanda 5"),
            }.AsQueryable();

        private static Entities.Comanda GetComanda(int id, string nome = "") =>
            new Entities.Comanda()
            {
                Id = id,
                Nome = nome
            };
    }
}