using E_Commerce_Backend.Application.Interfaces.RedisCache;
using MediatR;

namespace E_Commerce_Backend.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryRequest:IRequest<IList<GetAllProductsQueryResponse>>,ICacheableQuery
{
    public string CacheKey => "GetAllProducts";
    public double CacheTime => 60;
}
