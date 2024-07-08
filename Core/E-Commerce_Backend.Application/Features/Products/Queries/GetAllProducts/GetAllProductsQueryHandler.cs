using E_Commerce_Backend.Application.UnitOfWorks;
using MediatR;
using E_Commerce_Backend.Domain.Entities;
using E_Commerce_Backend.Application.Interfaces.AutoMapper;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Backend.Application.DTOs;

namespace E_Commerce_Backend.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler(IUnitOfWork _unitOfWork,IMapper _mapper) : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
{
    public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var products=await _unitOfWork.GetReadRepository<Product>().GetAllAsync(
            include:x=>x.Include(b=>b.Brand)
        ); 

        var brand=_mapper.Map<BrandDto,Brand>(new Brand());

        var response=_mapper.Map<GetAllProductsQueryResponse,Product>(products);

        foreach (var item in response){
            item.Price-=item.Price*item.Discount/100;
        }

        return response;
    }

}
