using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class Supplier
    {
        public int PersonId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string AgencyName { get; set; } = null!;
        public string? AccountNumber { get; set; }
        public int Deleted { get; set; }

        public virtual Person Person { get; set; } = null!;
    }
}
