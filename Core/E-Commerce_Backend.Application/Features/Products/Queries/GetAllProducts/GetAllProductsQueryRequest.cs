using MediatR;

namespace E_Commerce_Backend.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryRequest:IRequest<IList<GetAllProductsQueryResponse>>
{

}
