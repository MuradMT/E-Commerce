using E_Commerce_Backend.Application.Bases;
using E_Commerce_Backend.Application.Interfaces.AutoMapper;
using E_Commerce_Backend.Application.UnitOfWorks;
using E_Commerce_Backend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_Commerce_Backend.Application.Features.Brands.Queries.GetAllBrands;

public class GetAllBrandsHandler:BaseHandler,IRequestHandler<GetAllBrandsRequest,IList<GetAllBrandsResponse>>
{
    public GetAllBrandsHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor context) : base(unitOfWork, mapper, context)
    {
    }

    public async Task<IList<GetAllBrandsResponse>> Handle(GetAllBrandsRequest request, CancellationToken cancellationToken)
    {
        var brands = await _unitOfWork.GetReadRepository<Brand>().GetAllAsync();
        return  _mapper.Map<GetAllBrandsResponse, Brand>(brands);
    }
}