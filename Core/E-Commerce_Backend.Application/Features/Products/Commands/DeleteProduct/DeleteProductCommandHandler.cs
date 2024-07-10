using E_Commerce_Backend.Application.UnitOfWorks;
using E_Commerce_Backend.Domain.Entities;
using MediatR;

namespace E_Commerce_Backend.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler(IUnitOfWork _unitOfWork): IRequestHandler<DeleteProductCommandRequest>
{
    public async Task Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product=await _unitOfWork.GetReadRepository<Product>().GetAsync(x=>x.Id==request.Id && !x.IsDeleted);

        product.IsDeleted=true;

        await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
        await _unitOfWork.SaveAsync();
    }
}
