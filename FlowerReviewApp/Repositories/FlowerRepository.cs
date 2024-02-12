using FlowerReviewApp.Interfaces;
using FlowerReviewApp.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace FlowerReviewApp.Repositories
{
    public class FlowerRepository : IFlowerRepository
    {
        private readonly SONUNGVIENREVIEWContext _context;
        public FlowerRepository(SONUNGVIENREVIEWContext context) 
        {
            _context = context;
        }

        public DetailedProduct GetFlower(int id)
        {
            return _context.DetailedProducts.Where(p => p.DetailedProductId == id).FirstOrDefault();
        }

        public DetailedProduct GetFlower(string name)
        {
            return _context.DetailedProducts.Where(p => p.DetailedProductName == name).FirstOrDefault();
        }

        public decimal GetRating(int id)
        {
            IEnumerable<Review> review = _context.Reviews.Where(p => p.ReviewId == id);
            if (review.Count() <= 0)
                return 0;
            return ((decimal)review.Sum(r => r.Rating)) / review.Count();
        }

        public bool IsFlowerExists(int id)
        {
            return _context.DetailedProducts.Any(p => p.DetailedProductId.Equals(id));
        }

        public ICollection<DetailedProduct> GetFlowers()
        {
            return _context.DetailedProducts.OrderBy(p => p.DetailedProductId).ToList();
        }

        public bool CreateNewFlower(int ownerId, DetailedProduct flower)
        {
            var flowerOwnerEntity = _context.Owners.Where(o => o.OwnerId == ownerId).FirstOrDefault();
            var flowerOwner = new DetailedProductOwner
            {
                Owner = flowerOwnerEntity,
                DetailedProduct = flower
            };
            _context.Add(flowerOwner);
            _context.Add(flower);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
