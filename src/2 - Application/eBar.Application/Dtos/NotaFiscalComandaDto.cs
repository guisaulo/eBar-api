using System.Collections.Generic;

namespace eBar.Application.Dtos
{
    public class NotaFiscalComandaDto
    {
        public List<ItemDto> Items { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
