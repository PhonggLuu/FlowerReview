using FlowerReviewApp.Models;

namespace FlowerReviewApp.Interfaces
{
    public interface IReviewerRepository
    {
        Task<ICollection<Reviewer>> GetReviewers();
        Reviewer GetReviewer(int reviewerId);
        ICollection<Review> GetReviewByReviewer(int reviewerId);
        bool IsReviewerExists(int reviewerId); 
        bool CreateReviewer(Reviewer reviewer);
        bool UpdateReviewer(Reviewer reviewer);
        bool DeleteReviewer(Reviewer reviewer);
        bool Save();
    }
}
