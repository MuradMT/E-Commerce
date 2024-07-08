using E_Commerce_Backend.Application.DTOs;

namespace E_Commerce_Backend.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryResponse
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    //public required string ImagePath { get; set; }

    public decimal Price { get; set; }

    public decimal Discount { get; set; }

    public BrandDto? Brand { get; set; }

}
