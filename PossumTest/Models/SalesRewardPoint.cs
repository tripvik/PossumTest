using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class SalesRewardPoint
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public float Earned { get; set; }
        public float Used { get; set; }

        public virtual Sale Sale { get; set; } = null!;
    }
}
