using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class StockLocation
    {
        public StockLocation()
        {
            Inventories = new HashSet<Inventory>();
            ItemQuantities = new HashSet<ItemQuantity>();
            Permissions = new HashSet<Permission>();
            SalesItems = new HashSet<SalesItem>();
        }

        public int LocationId { get; set; }
        public string? LocationName { get; set; }
        public int Deleted { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<ItemQuantity> ItemQuantities { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<SalesItem> SalesItems { get; set; }
    }
}
