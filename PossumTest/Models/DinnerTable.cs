using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class DinnerTable
    {
        public DinnerTable()
        {
            Sales = new HashSet<Sale>();
        }

        public int DinnerTableId { get; set; }
        public string Name { get; set; } = null!;
        public short Status { get; set; }
        public int Deleted { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
