using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Models.DTOs;

public class ProductCreateDto
{
    [Required]
    [MinLength(2)]
    public string Name { get; set; }

    [Range(1,1000000)]
    [Price]
    public decimal Price { get; set; }
    [Required]
    public string Category { get; set; }
}