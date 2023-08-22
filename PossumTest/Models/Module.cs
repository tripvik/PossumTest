using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class Module
    {
        public Module()
        {
            Permissions = new HashSet<Permission>();
        }

        public string NameLangKey { get; set; } = null!;
        public string DescLangKey { get; set; } = null!;
        public int Sort { get; set; }
        public string ModuleId { get; set; } = null!;

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
