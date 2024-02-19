using FlowerReviewApp.Interfaces;
using FlowerReviewApp.Models;

namespace FlowerReviewApp.Repositories
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly SONUNGVIENREVIEWContext _context;
        public ReviewerRepository(SONUNGVIENREVIEWContext context)
        {
            _context = context;
        }

        public ICollection<Review> GetReviewByReviewer(int reviewerId)
        {
            return _context.Reviews.Where(r => r.Reviewer.ReviewerId == reviewerId).ToList();
        }

        public Reviewer GetReviewer(int reviewerId)
        {
            return _context.Reviewers.FirstOrDefault(r => r.ReviewerId == reviewerId);
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _context.Reviewers.ToList();
        }

        public bool IsReviewerExists(int reviewerId)
        {
            return _context.Reviewers.Any(r => r.ReviewerId == reviewerId);
        }

        public bool CreateReviewer(Reviewer reviewer)
        {
            _context.Add(reviewer);
            return Save();
        }

        public bool UpdateReviewer(Reviewer reviewer)
        {
            _context.Update(reviewer);
            return Save();
        }

        public bool DeleteReviewer(Reviewer reviewer)
        {
            _context.Remove(reviewer);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
