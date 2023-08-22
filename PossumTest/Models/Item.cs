using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class Item
    {
        public Item()
        {
            Inventories = new HashSet<Inventory>();
            ItemKitItems = new HashSet<ItemKitItem>();
            ItemQuantities = new HashSet<ItemQuantity>();
            ItemsTaxes = new HashSet<ItemsTaxis>();
            ReceivingsItems = new HashSet<ReceivingsItem>();
            SalesItems = new HashSet<SalesItem>();
            SalesItemsTaxes = new HashSet<SalesItemsTaxis>();
        }

        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public int? SupplierId { get; set; }
        public string? ItemNumber { get; set; }
        public string Description { get; set; } = null!;
        public decimal CostPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ReorderLevel { get; set; }
        public decimal ReceivingQuantity { get; set; }
        public int ItemId { get; set; }
        public string? PicFilename { get; set; }
        public short AllowAltDescription { get; set; }
        public short IsSerialized { get; set; }
        public short StockType { get; set; }
        public short ItemType { get; set; }
        public int Deleted { get; set; }
        public string? Custom1 { get; set; }
        public string? Custom2 { get; set; }
        public string? Custom3 { get; set; }
        public string? Custom4 { get; set; }
        public string? Custom5 { get; set; }
        public string? Custom6 { get; set; }
        public string? Custom7 { get; set; }
        public string? Custom8 { get; set; }
        public string? Custom9 { get; set; }
        public string? Custom10 { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<ItemKitItem> ItemKitItems { get; set; }
        public virtual ICollection<ItemQuantity> ItemQuantities { get; set; }
        public virtual ICollection<ItemsTaxis> ItemsTaxes { get; set; }
        public virtual ICollection<ReceivingsItem> ReceivingsItems { get; set; }
        public virtual ICollection<SalesItem> SalesItems { get; set; }
        public virtual ICollection<SalesItemsTaxis> SalesItemsTaxes { get; set; }
    }
}
