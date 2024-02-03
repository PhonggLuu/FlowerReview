using System;
using System.Collections.Generic;

namespace FlowerReviewApp.Models
{
    public partial class Country
    {
        public Country()
        {
            Owners = new HashSet<Owner>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Owner> Owners { get; set; }
    }
}
