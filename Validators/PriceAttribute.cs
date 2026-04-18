using System.ComponentModel.DataAnnotations;

public class PriceAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
{
    if (value == null)
        return new ValidationResult("Price is required");

    if (value is decimal price && price <= 0)
        return new ValidationResult("Price must be greater than zero.");

    return ValidationResult.Success;
}
}