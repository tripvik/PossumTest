using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class Permission
    {
        public Permission()
        {
            Grants = new HashSet<Grant>();
        }

        public string PermissionId { get; set; } = null!;
        public string ModuleId { get; set; } = null!;
        public int? LocationId { get; set; }

        public virtual StockLocation? Location { get; set; }
        public virtual Module Module { get; set; } = null!;
        public virtual ICollection<Grant> Grants { get; set; }
    }
}
