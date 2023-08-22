using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class ItemsTaxis
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Percent { get; set; }

        public virtual Item Item { get; set; } = null!;
    }
}
