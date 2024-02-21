using FlowerReviewApp.Interfaces;
using FlowerReviewApp.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task< ICollection<Reviewer>> GetReviewers()
        {
            return await _context.Reviewers.ToListAsync();
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

            var reviews = _context.Reviews.Where(r => r.Reviewer.ReviewerId == reviewer.ReviewerId);
            _context.Reviews.RemoveRange(reviews);
            _context.Remove(reviewer);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
