using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class TaxCategory
    {
        public int TaxCategoryId { get; set; }
        public string TaxCategory1 { get; set; } = null!;
        public short TaxGroupSequence { get; set; }
    }
}
