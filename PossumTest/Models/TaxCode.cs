using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class TaxCode
    {
        public string TaxCode1 { get; set; } = null!;
        public string TaxCodeName { get; set; } = null!;
        public short TaxCodeType { get; set; }
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
    }
}
