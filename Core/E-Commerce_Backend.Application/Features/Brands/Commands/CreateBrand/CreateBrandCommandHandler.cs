using Bogus;
using E_Commerce_Backend.Application.Bases;
using E_Commerce_Backend.Application.Interfaces.AutoMapper;
using E_Commerce_Backend.Application.UnitOfWorks;
using E_Commerce_Backend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_Commerce_Backend.Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandHandler:BaseHandler,IRequestHandler<CreateBrandCommandRequest,Unit>
{
    public CreateBrandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor context) : base(unitOfWork, mapper, context)
    {
    }
    public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
    {
        Faker faker = new();
        List<Brand> brands = new();
        for (int i = 0; i < 1000000; i++)
        {
            brands.Add(new(faker.Commerce.Department(1)));
        }

        await _unitOfWork.GetWriteRepository<Brand>().AddRangeAsync(brands);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}