﻿using System.Collections.Generic;

namespace TestDgBar.Domain.Entities
{
    public class NotaFiscalComanda
    {
        public List<Item> Items { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }
    }
}