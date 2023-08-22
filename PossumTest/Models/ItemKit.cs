using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class ItemKit
    {
        public ItemKit()
        {
            ItemKitItems = new HashSet<ItemKitItem>();
        }

        public int ItemKitId { get; set; }
        public string Name { get; set; } = null!;
        public int ItemId { get; set; }
        public decimal KitDiscountPercent { get; set; }
        public short PriceOption { get; set; }
        public short PrintOption { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<ItemKitItem> ItemKitItems { get; set; }
    }
}
