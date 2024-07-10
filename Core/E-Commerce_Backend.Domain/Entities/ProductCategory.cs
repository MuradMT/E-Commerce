using E_Commerce_Backend.Domain.Common;

namespace E_Commerce_Backend.Domain.Entities;

public class ProductCategory : EntityBase
{
    public ProductCategory()
    {
        
    }

    public ProductCategory(int productId,int categoryId)
    {
        ProductId=productId;
        CategoryId=categoryId;
    }
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }



}
