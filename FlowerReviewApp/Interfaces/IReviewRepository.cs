﻿using FlowerReviewApp.Models;

namespace FlowerReviewApp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);
        ICollection<Review> GetReviewOfAFlower(int flowerId);
        bool HasReview(int reviewId);
        bool CreateReview(Review review);
        bool Save();
    }
}
