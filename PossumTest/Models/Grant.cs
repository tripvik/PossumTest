using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class Grant
    {
        public string PermissionId { get; set; } = null!;
        public int PersonId { get; set; }
        public string? MenuGroup { get; set; }

        public virtual Permission Permission { get; set; } = null!;
    }
}
