using FlowerReviewApp.Interfaces;
using FlowerReviewApp.Models;

namespace FlowerReviewApp.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly SONUNGVIENREVIEWContext _context;
        public ReviewRepository(SONUNGVIENREVIEWContext context)
        {
            _context = context;
        }

        public Review GetReview(int reviewId)
        {
            return _context.Reviews.Where(r => r.ReviewId == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviewOfAFlower(int flowerId)
        {
            return _context.DetailedProducts.Where(f => f.DetailedProductId == flowerId).Select(r => r.Reviews).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public bool HasReview(int reviewId)
        {
            return _context.Reviews.Where(r => r.ReviewId == reviewId).Any();
        }

        public bool CreateReview(Review review)
        {
            _context.Add(review);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
