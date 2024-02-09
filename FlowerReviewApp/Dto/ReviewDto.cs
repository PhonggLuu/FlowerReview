namespace FlowerReviewApp.Dto
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
        public int Rating { get; set; }
    }
}
