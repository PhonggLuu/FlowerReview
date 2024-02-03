using System;
using System.Collections.Generic;

namespace FlowerReviewApp.Models
{
    public partial class Reviewer
    {
        public Reviewer()
        {
            Reviews = new HashSet<Review>();
        }

        public int ReviewerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
