using FlowerReviewApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerReviewApp.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Owner> GetOwnerOfAFlower(int flowerId);
        ICollection<DetailedProduct> GetFlowerOfOwner(int ownerId);
        bool IsOwnerExists(int ownerId);
        public bool CreateOwner(Owner owner);
        public bool Save();
    }
}
