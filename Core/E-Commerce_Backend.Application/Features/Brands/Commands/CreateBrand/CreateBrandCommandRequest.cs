using MediatR;

namespace E_Commerce_Backend.Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandRequest:IRequest<Unit>
{
    public string Name { get; set; }
}