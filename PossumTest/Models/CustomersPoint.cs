using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class CustomersPoint
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int PackageId { get; set; }
        public int SaleId { get; set; }
        public int PointsEarned { get; set; }

        public virtual CustomersPackage Package { get; set; } = null!;
        public virtual Sale Sale { get; set; } = null!;
    }
}
