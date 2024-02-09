using System;
using System.Collections.Generic;

namespace FlowerReviewApp.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
        public int Rating { get; set; }
        public int DetailedProductId { get; set; }
        public int ReviewerId { get; set; }
        public virtual DetailedProduct DetailedProduct { get; set; } = null!;
        public virtual Reviewer Reviewer { get; set; } = null!;
    }
}
