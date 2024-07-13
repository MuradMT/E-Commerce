using E_Commerce_Backend.Application.Bases;
using E_Commerce_Backend.Application.Constants;

namespace E_Commerce_Backend.Application.Features.Products.Exceptions;

public class ProductTitleMustNotBeSameException:BaseExceptions
{
    public ProductTitleMustNotBeSameException():base(ProductMessages.Title_Must_Not_Be_Same) {}
}