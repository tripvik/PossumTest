using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class Customer
    {
        public int PersonId { get; set; }
        public string? CompanyName { get; set; }
        public string? AccountNumber { get; set; }
        public int Taxable { get; set; }
        public string SalesTaxCode { get; set; } = null!;
        public decimal DiscountPercent { get; set; }
        public int? PackageId { get; set; }
        public int? Points { get; set; }
        public int Deleted { get; set; }

        public virtual CustomersPackage? Package { get; set; }
        public virtual Person Person { get; set; } = null!;
    }
}
