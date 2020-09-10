using System.Collections.Generic;

namespace TestDgBar.Domain.Entities
{
    public class Comanda : Base
    {
        public string Nome { get; set; }
        public virtual ICollection<ComandaItem> ComandaItem { get; set; }
    }
}