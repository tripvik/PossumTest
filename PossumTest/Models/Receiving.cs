using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class Receiving
    {
        public Receiving()
        {
            ReceivingsItems = new HashSet<ReceivingsItem>();
        }

        public DateTime ReceivingTime { get; set; }
        public int? SupplierId { get; set; }
        public int EmployeeId { get; set; }
        public string? Comment { get; set; }
        public int ReceivingId { get; set; }
        public string? PaymentType { get; set; }
        public string? Reference { get; set; }

        public virtual ICollection<ReceivingsItem> ReceivingsItems { get; set; }
    }
}
