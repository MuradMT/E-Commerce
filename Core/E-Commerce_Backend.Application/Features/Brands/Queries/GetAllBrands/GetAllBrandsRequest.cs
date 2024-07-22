using E_Commerce_Backend.Application.Interfaces.RedisCache;
using MediatR;

namespace E_Commerce_Backend.Application.Features.Brands.Queries.GetAllBrands;

public class GetAllBrandsRequest:IRequest<IList<GetAllBrandsResponse>>,ICacheableQuery
{
    public string CacheKey => "GetAllBrands";
    public double CacheTime => 5;
}