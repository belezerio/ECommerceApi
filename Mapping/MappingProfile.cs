using AutoMapper;
using ECommerceApi.Models.Entities;
using ECommerceApi.Models.DTOs;

namespace ECommerceApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductReadDto>();
        CreateMap<ProductCreateDto, Product>();
    }
}