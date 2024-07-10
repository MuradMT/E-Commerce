using E_Commerce_Backend.Application.UnitOfWorks;
using MediatR;
using E_Commerce_Backend.Domain.Entities;
using E_Commerce_Backend.Application.Interfaces.AutoMapper;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Backend.Application.DTOs;

namespace E_Commerce_Backend.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
{
    public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include: x => x.Include(b => b.Brand));

            var brand = mapper.Map<BrandDto, Brand>(new Brand());

            var map = mapper.Map<GetAllProductsQueryResponse, Product>(products);
            foreach (var item in map)
                item.Price -= (item.Price * item.Discount / 100);

            return map;
    }

}
