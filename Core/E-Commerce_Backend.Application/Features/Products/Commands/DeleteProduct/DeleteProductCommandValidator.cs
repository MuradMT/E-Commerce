using FluentValidation;
namespace E_Commerce_Backend.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandValidator:AbstractValidator<DeleteProductCommandRequest>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
    }
}