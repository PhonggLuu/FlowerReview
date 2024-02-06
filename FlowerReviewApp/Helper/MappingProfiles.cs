using AutoMapper;
using FlowerReviewApp.Dto;
using FlowerReviewApp.Models;

namespace FlowerReviewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<DetailedProduct, FlowerDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Product, ProductDto>();
        }
    }
}
