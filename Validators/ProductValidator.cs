using FluentValidation;
using ECommerceApi.Models.DTOs;

namespace ECommerceApi.Validators;
public class ProductValidator : AbstractValidator<ProductCreateDto>
{
    public ProductValidator()
    {
        RuleFor( x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(2).WithMessage("Name must be at least 2 characters long");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");
        
        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category is required");    
    }
}