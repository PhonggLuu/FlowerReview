using FlowerReviewApp.Interfaces;
using FlowerReviewApp.Models;

namespace FlowerReviewApp.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly SONUNGVIENREVIEWContext _context;
        public OwnerRepository (SONUNGVIENREVIEWContext context)
        {
            _context = context;
        }
        public ICollection<DetailedProduct> GetFlowerOfOwner(int ownerId)
        {
            return _context.DetailedProductOwners.Where(f => f.OwnerId == ownerId).Select(p => p.DetailedProduct).ToList();
        }

        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.OwnerId == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfAFlower(int flowerId)
        {
            return _context.DetailedProductOwners.Where(f => f.DetailedProductId == flowerId).Select(p => p.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public bool IsOwnerExists(int ownerId)
        {
            return _context.Owners.Any(o => o.OwnerId == ownerId);
        }
    }
}
