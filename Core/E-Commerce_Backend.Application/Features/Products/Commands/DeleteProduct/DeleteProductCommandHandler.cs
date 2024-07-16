using E_Commerce_Backend.Application.Bases;
using E_Commerce_Backend.Application.Interfaces.AutoMapper;
using E_Commerce_Backend.Application.UnitOfWorks;
using E_Commerce_Backend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_Commerce_Backend.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandle:BaseHandler,IRequestHandler<DeleteProductCommandRequest,Unit>
{
    public DeleteProductCommandHandle(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor context) : base(unitOfWork, mapper, context)
    {
    }
    public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product=await _unitOfWork.GetReadRepository<Product>().GetAsync(x=>x.Id==request.Id && !x.IsDeleted);

        product.IsDeleted=true;

        await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
