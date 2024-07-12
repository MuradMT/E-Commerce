using FluentValidation;

namespace E_Commerce_Backend.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator:AbstractValidator<CreateProductCommandRequest>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title");//you can not write this line,
        //it is useful if you use different name from your entity

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description");

        RuleFor(x => x.BrandId)
            .GreaterThan(0)
            .WithMessage("Brand");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price");

        RuleFor(x => x.Discount)
            .GreaterThan(0)
            .WithMessage("Discount");

        RuleFor(x => x.CategoryIds)
            .NotEmpty()
            .Must(categories=>categories.Any())
            .WithMessage("Categories");

    }
}