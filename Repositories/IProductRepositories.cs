using ECommerceApi.Models.Entities;

namespace ECommerceApi.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task AddAsync(Product product);
    Task SaveChangesAsync();
    Task <(IEnumerable<Product>,int)> GetPagedAsync(int pageNumber, int pageSize, string? category , string? sortBy);
}