using BusinessLogicLayer.DTOs;
using FluentValidation;
namespace BusinessLogicLayer.Validators;

public class CreateProductDtoValidator : AbstractValidator<CreateProductDTO>
{
    public CreateProductDtoValidator()
    {
        RuleFor(a => a.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(a => a.Name).Length(1, 255).WithMessage("Name must be between 1 and 255 characters")
            .NotEmpty().WithMessage("Name is required");
        RuleFor(a => a.Price).GreaterThan(1).NotEmpty().WithMessage("Price is required");
        RuleFor(a => a.QuantityInStock).GreaterThan(0);
    }
}