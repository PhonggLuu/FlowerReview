using System;
using System.Collections.Generic;

namespace FlowerReviewApp.Models
{
    public partial class DetailedProduct
    {
        public DetailedProduct()
        {
            Reviews = new HashSet<Review>();
            DetailedProductOwners = new HashSet<DetailedProductOwner>();
        }
        public int DetailedProductId { get; set; }
        public string DetailedProductName { get; set; } = null!;
        public string? Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<DetailedProductOwner> DetailedProductOwners { get; set; }
    }
}
