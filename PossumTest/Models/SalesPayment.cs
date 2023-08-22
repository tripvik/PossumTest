using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class SalesPayment
    {
        public int SaleId { get; set; }
        public string PaymentType { get; set; } = null!;
        public decimal PaymentAmount { get; set; }

        public virtual Sale Sale { get; set; } = null!;
    }
}
