﻿using FlowerReviewApp.Models;
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
        bool IsReference(int ownerId);
        public bool CreateOwner(Owner owner);
        public bool UpdateOwner(Owner owner);
        public bool DeleteOwner(Owner owner);
        public bool Save();
    }
}
