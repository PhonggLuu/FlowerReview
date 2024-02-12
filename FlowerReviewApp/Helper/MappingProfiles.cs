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
            CreateMap<FlowerDto, DetailedProduct>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>().ReverseMap();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>().ReverseMap();

            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();

            CreateMap<Owner, OwnerDto>();
            CreateMap<OwnerDto, Owner>();

            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();

            CreateMap<Reviewer, ReviewerDto>();
            CreateMap<ReviewerDto, Reviewer>();
        }
    }
}
