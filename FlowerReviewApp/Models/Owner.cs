using System;
using System.Collections.Generic;

namespace FlowerReviewApp.Models
{
    public partial class Owner
    {
        public Owner() 
        {
            DetailedProductOwners = new HashSet<DetailedProductOwner>();
        }
        public int OwnerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int CountryID { get; set; }
        public virtual Country Country { get; set; } = null!;
        public ICollection<DetailedProductOwner> DetailedProductOwners { get; set; }
    }
}
