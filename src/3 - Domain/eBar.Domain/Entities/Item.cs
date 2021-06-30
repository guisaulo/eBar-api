using System.Collections.Generic;

namespace eBar.Domain.Entities
{
    public class Item : Base
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}