using FlowerReviewApp.Models;

namespace FlowerReviewApp.Interfaces
{
    public interface IFlowerRepository
    {
        ICollection<DetailedProduct> GetFlowers();
        DetailedProduct GetFlower(int id);
        DetailedProduct GetFlower(string name);
        decimal GetRating(int id);
        bool IsFlowerExists(int id);

    }
}
