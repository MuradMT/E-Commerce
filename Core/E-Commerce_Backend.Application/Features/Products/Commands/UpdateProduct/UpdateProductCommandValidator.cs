using FluentValidation;

namespace E_Commerce_Backend.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandValidator:AbstractValidator<UpdateProductCommandRequest>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
            
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