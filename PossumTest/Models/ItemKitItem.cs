using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class ItemKitItem
    {
        public int ItemKitId { get; set; }
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }
        public int KitSequence { get; set; }

        public virtual Item Item { get; set; } = null!;
        public virtual ItemKit ItemKit { get; set; } = null!;
    }
}
