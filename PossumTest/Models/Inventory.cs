using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class Inventory
    {
        public int TransId { get; set; }
        public int TransItems { get; set; }
        public int TransUser { get; set; }
        public DateTime TransDate { get; set; }
        public string TransComment { get; set; } = null!;
        public int TransLocation { get; set; }
        public decimal TransInventory { get; set; }

        public virtual Item TransItemsNavigation { get; set; } = null!;
        public virtual StockLocation TransLocationNavigation { get; set; } = null!;
    }
}
