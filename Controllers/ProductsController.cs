using ECommerceApi.Models.DTOs;
using ECommerceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers;

[ApiController]
[Route("api/v1/products")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _service;

    public ProductsController(ProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductReadDto>>> Get()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ProductReadDto>> Create(ProductCreateDto createDto)
    {
        var result = await _service.CreateAsync(createDto);
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult> GetAll(int PageNumber = 1, int PageSize = 10, string? category = null, string? sortBy = null)
    {
        var result = await _service.GetPagedAsync(PageNumber, PageSize, category, sortBy);
        return Ok(result);
    }
}