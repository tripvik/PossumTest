using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class Employee
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int PersonId { get; set; }
        public int Deleted { get; set; }
        public int HashVersion { get; set; }
        public string? Language { get; set; }
        public string? LanguageCode { get; set; }

        public virtual Person Person { get; set; } = null!;
    }
}
