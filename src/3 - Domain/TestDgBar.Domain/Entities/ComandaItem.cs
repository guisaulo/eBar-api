namespace TestDgBar.Domain.Entities
{
    public class ComandaItem
    {
        public int ComandaId { get; set; }
        public int ItemId { get; set; }
        public virtual Comanda Comanda { get; set; }
        public virtual Item Item { get; set; }
    }
}
