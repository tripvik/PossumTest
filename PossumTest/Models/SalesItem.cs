using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class SalesItem
    {
        public int SaleId { get; set; }
        public int ItemId { get; set; }
        public string? Description { get; set; }
        public string? Serialnumber { get; set; }
        public int Line { get; set; }
        public decimal QuantityPurchased { get; set; }
        public decimal ItemCostPrice { get; set; }
        public decimal ItemUnitPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public int ItemLocation { get; set; }
        public short PrintOption { get; set; }

        public virtual Item Item { get; set; } = null!;
        public virtual StockLocation ItemLocationNavigation { get; set; } = null!;
        public virtual Sale Sale { get; set; } = null!;
    }
}
