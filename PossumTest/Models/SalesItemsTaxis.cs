using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class SalesItemsTaxis
    {
        public int SaleId { get; set; }
        public int ItemId { get; set; }
        public int Line { get; set; }
        public string Name { get; set; } = null!;
        public decimal Percent { get; set; }
        public short TaxType { get; set; }
        public short RoundingCode { get; set; }
        public short CascadeTax { get; set; }
        public short CascadeSequence { get; set; }
        public decimal ItemTaxAmount { get; set; }

        public virtual Item Item { get; set; } = null!;
    }
}
