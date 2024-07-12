using E_Commerce_Backend.Application.Interfaces.AutoMapper;
using E_Commerce_Backend.Application.UnitOfWorks;
using E_Commerce_Backend.Domain.Entities;
using MediatR;

namespace E_Commerce_Backend.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler(IUnitOfWork _unitOfWork,IMapper _mapper): IRequestHandler<UpdateProductCommandRequest,Unit>
{
    public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product=await _unitOfWork.GetReadRepository<Product>().GetAsync(x=>x.Id==request.Id && !x.IsDeleted);
        var result=_mapper.Map<Product,UpdateProductCommandRequest>(request);

        var productCategories=await _unitOfWork.GetReadRepository<ProductCategory>().
        GetAllAsync(x=>x.ProductId==product.Id);

        await _unitOfWork.GetWriteRepository<ProductCategory>().HardDeleteRangeAsync(productCategories);
        foreach (var categoryId in request.CategoryIds)
            {
               await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(
                  new(){
                    ProductId=product.Id,
                    CategoryId=categoryId
                  }
               );
            }

        await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(result);
      
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
