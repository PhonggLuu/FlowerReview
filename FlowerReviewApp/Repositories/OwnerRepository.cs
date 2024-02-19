using FlowerReviewApp.Interfaces;
using FlowerReviewApp.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

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


        public bool IsReference(int ownerId)
        {
            return _context.DetailedProductOwners.Any(o => o.OwnerId == ownerId);
        }

        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return Save();
        }

        public bool UpdateOwner(Owner owner)
        {
            _context.Update(owner);
            return Save();
        }

        public bool DeleteOwner(Owner owner)
        {
            var flowerOwner = _context.DetailedProductOwners.Where(o => o.OwnerId == owner.OwnerId).FirstOrDefault();
            if (flowerOwner != null)
            {
                _context.Remove(flowerOwner);
            }
            _context.Remove(owner);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
