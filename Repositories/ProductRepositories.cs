using Microsoft.EntityFrameworkCore;
using ECommerceApi.Data;
using ECommerceApi.Models.Entities;

namespace ECommerceApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<(IEnumerable<Product> , int)> GetPagedAsync(int PageNumber , int PageSize, string? category , string? sortBy)
    {
        var query = _context.Products.AsQueryable();
        if(!string.IsNullOrEmpty(category))
        {
            query = query.Where(p => p.Category == category);
        }

        query = sortBy?.ToLower() switch
        {
            "price" => query.OrderBy(p => p.Price),
            "name" => query.OrderBy(p => p.Name),
            _ => query
        };

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((PageNumber - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();
        return (items, totalCount);
    }
}