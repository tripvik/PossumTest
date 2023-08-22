using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class ItemQuantity
    {
        public int ItemId { get; set; }
        public int LocationId { get; set; }
        public decimal Quantity { get; set; }

        public virtual Item Item { get; set; } = null!;
        public virtual StockLocation Location { get; set; } = null!;
    }
}
