using E_Commerce_Backend.Application.Bases;
using E_Commerce_Backend.Application.Features.Products.Exceptions;
using E_Commerce_Backend.Domain.Entities;

namespace E_Commerce_Backend.Application.Features.Products.Rules;

public class ProductRules:BaseRules
{
    public Task ProductTitleMustNotBeSame(IList<Product> products,string requestTitle)
    {
        if (products.Any(x=>x.Title==requestTitle)) throw new ProductTitleMustNotBeSameException();
        return Task.CompletedTask;
    }
}