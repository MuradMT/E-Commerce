using E_Commerce_Backend.Application.UnitOfWorks;
using MediatR;
using E_Commerce_Backend.Domain.Entities;

namespace E_Commerce_Backend.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
{
    public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var products=await _unitOfWork.GetReadRepository<Product>().GetAllAsync();
        List<GetAllProductsQueryResponse> response = new();

        foreach (var product in products)
        {
            response.Add(
            new GetAllProductsQueryResponse(){
                Title = product.Title,
                Description = product.Description,
                Price = product.Price-(product.Price*product.Discount/100),
                Discount = product.Discount
            });
        }
        return response;
    }

}
