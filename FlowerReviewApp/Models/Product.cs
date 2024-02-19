using System;
using System.Collections.Generic;

namespace FlowerReviewApp.Models
{
    public partial class Product
    {
        public Product()
        {
            DetailedProducts = new HashSet<DetailedProduct>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<DetailedProduct> DetailedProducts { get; set; }
    }
}
