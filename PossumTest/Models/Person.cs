using System;
using System.Collections.Generic;

namespace PossumTest.Models
{
    public partial class Person
    {
        public Person()
        {
            Giftcards = new HashSet<Giftcard>();
        }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? Gender { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address1 { get; set; } = null!;
        public string Address2 { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Zip { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Comments { get; set; } = null!;
        public int PersonId { get; set; }

        public virtual ICollection<Giftcard> Giftcards { get; set; }
    }
}
