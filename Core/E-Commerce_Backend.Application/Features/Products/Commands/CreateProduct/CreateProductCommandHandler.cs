﻿using E_Commerce_Backend.Application.UnitOfWorks;
using E_Commerce_Backend.Domain.Entities;
using MediatR;

namespace E_Commerce_Backend.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(IUnitOfWork _unitOfWork): IRequestHandler<CreateProductCommandRequest>
{

    public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
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
    }
}
