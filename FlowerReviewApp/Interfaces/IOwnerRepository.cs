using FlowerReviewApp.Models;

namespace FlowerReviewApp.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Owner> GetOwnerOfAFlower(int flowerId);
        ICollection<DetailedProduct> GetFlowerOfOwner(int ownerId);
        bool IsOwnerExists(int ownerId);
    }
}
