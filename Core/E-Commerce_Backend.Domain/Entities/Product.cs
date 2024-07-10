using E_Commerce_Backend.Domain.Common;

namespace E_Commerce_Backend.Domain.Entities;

public class Product:EntityBase
{
    public Product()
    {
        
    }
    public Product(string title,string description,decimal price,decimal discount,int brandId)
    {
        Title=title;
        Description=description;
        Price=price;
        Discount=discount;
        BrandId=brandId;
    }
    public  string? Title { get; set; }
    public  string? Description { get; set; }
    //public required string ImagePath { get; set; }

    public  decimal Price { get; set; }

    public  decimal Discount { get; set; }

    public  int BrandId { get; set; }
    public Brand Brand { get; set; }

    public ICollection<ProductCategory> ProductCategories { get; set; }
}
