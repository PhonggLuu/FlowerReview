using System;
using System.Collections.Generic;

namespace FlowerReviewApp.Models
{
    public partial class DetailedProductOwner
    {
        public int OwnerId { get; set; }
        public int DetailedProductId { get; set; }

        public virtual DetailedProduct DetailedProduct { get; set; } = null!;
        public virtual Owner Owner { get; set; } = null!;
    }
}
