using FlowerReviewApp.Models;

namespace FlowerReviewApp.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int reviewerId);
        ICollection<Review> GetReviewByReviewer(int reviewerId);
        bool IsReviewerExists(int reviewerId);
    }
}
