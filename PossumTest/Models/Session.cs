using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class Session
    {
        public string Id { get; set; } = null!;
        public string IpAddress { get; set; } = null!;
        public long Timestamp { get; set; }
        public byte[] Data { get; set; } = null!;
    }
}
