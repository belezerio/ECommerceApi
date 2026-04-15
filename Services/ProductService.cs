using AutoMapper;
using ECommerceApi.Models.DTOs;
using ECommerceApi.Models.Entities;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services;

public class ProductService
{
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ProductReadDto>> GetAllAsync()
    {
        var products = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductReadDto>>(products);
    }
    public async Task<ProductReadDto> CreateAsync(ProductCreateDto createDto)
    {
        var product = _mapper.Map<Product>(createDto);
        await _repo.AddAsync(product);
        await _repo.SaveChangesAsync();
        return _mapper.Map<ProductReadDto>(product);
    }
}