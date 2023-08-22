using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class CustomersPackage
    {
        public CustomersPackage()
        {
            CustomersPoints = new HashSet<CustomersPoint>();
        }

        public int PackageId { get; set; }
        public string? PackageName { get; set; }
        public float PointsPercent { get; set; }
        public int Deleted { get; set; }

        public virtual ICollection<CustomersPoint> CustomersPoints { get; set; }
    }
}
