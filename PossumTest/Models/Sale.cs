using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class Sale
    {
        public Sale()
        {
            CustomersPoints = new HashSet<CustomersPoint>();
            SalesItems = new HashSet<SalesItem>();
            SalesPayments = new HashSet<SalesPayment>();
            SalesRewardPoints = new HashSet<SalesRewardPoint>();
        }

        public DateTime SaleTime { get; set; }
        public int? CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public string? Comment { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? QuoteNumber { get; set; }
        public int SaleId { get; set; }
        public short SaleStatus { get; set; }
        public int? DinnerTableId { get; set; }
        public string? WorkOrderNumber { get; set; }
        public short SaleType { get; set; }

        public virtual DinnerTable? DinnerTable { get; set; }
        public virtual ICollection<CustomersPoint> CustomersPoints { get; set; }
        public virtual ICollection<SalesItem> SalesItems { get; set; }
        public virtual ICollection<SalesPayment> SalesPayments { get; set; }
        public virtual ICollection<SalesRewardPoint> SalesRewardPoints { get; set; }
    }
}
