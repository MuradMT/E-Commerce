using MediatR;

namespace E_Commerce_Backend.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandRequest:IRequest
{
    public int Id { get; set; }
}
