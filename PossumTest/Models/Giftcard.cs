using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class Giftcard
    {
        public DateTime RecordTime { get; set; }
        public int GiftcardId { get; set; }
        public string? GiftcardNumber { get; set; }
        public decimal Value { get; set; }
        public int Deleted { get; set; }
        public int? PersonId { get; set; }

        public virtual Person? Person { get; set; }
    }
}
