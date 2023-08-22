using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class SalesTaxis
    {
        public int SaleId { get; set; }
        public short TaxType { get; set; }
        public string TaxGroup { get; set; } = null!;
        public decimal SaleTaxBasis { get; set; }
        public decimal SaleTaxAmount { get; set; }
        public short PrintSequence { get; set; }
        public string Name { get; set; } = null!;
        public decimal TaxRate { get; set; }
        public string SalesTaxCode { get; set; } = null!;
        public short RoundingCode { get; set; }
    }
}
