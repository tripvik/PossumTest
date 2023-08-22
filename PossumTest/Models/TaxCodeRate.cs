using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class TaxCodeRate
    {
        public string RateTaxCode { get; set; } = null!;
        public int RateTaxCategoryId { get; set; }
        public decimal TaxRate { get; set; }
        public short RoundingCode { get; set; }
    }
}
