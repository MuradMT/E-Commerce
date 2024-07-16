using E_Commerce_Backend.Application.Bases;
using E_Commerce_Backend.Application.Features.Products.Rules;
using E_Commerce_Backend.Application.Interfaces.AutoMapper;
using E_Commerce_Backend.Application.UnitOfWorks;
using E_Commerce_Backend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_Commerce_Backend.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler:BaseHandler,IRequestHandler<CreateProductCommandRequest,Unit>
{
    private readonly ProductRules _rules;
    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor context,ProductRules rules) : base(unitOfWork, mapper, context)
    {
        _rules = rules;
    }
    public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        IList<Product> products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();

        await _rules.ProductTitleMustNotBeSame(products, request.Title);
        
        Product product=new(request.Title,request.Description,request.Price,request.Discount,request.BrandId);

        await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);
        if(await _unitOfWork.SaveAsync() > 0){
            foreach (var categoryId in request.CategoryIds)
            {
               await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(
                  new(){
                    ProductId=product.Id,
                    CategoryId=categoryId
                  }
               );
               await _unitOfWork.SaveAsync();
            }
           
        }

        return Unit.Value;
    }
}
