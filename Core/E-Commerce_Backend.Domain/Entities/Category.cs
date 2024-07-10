using E_Commerce_Backend.Domain.Common;

namespace E_Commerce_Backend.Domain.Entities;


/// <summary>
/// This properties demonstrate how to create category and it's sub-categories.
/// </summary>
/// <param name="ParentId">The number of parent category id.</param>
/// <param name="Name">Name of category.</param>
/// <param name="Priority">The priority of category in it's main category.</param>
/// <returns>New Category class instance with 2 constructor overload.</returns> 
public class Category:EntityBase
{
    public Category()
    {
        
    }
    public Category(int parentId,string name,int priority)
    {
        ParentId = parentId;
        Name = name;
        Priority = priority;
    }
    public  int ParentId { get; set; }

    public  string? Name { get; set; }

    public  int Priority { get; set; }

    public ICollection<Detail> Details { get; set; }
    public ICollection<ProductCategory> ProductCategories { get; set; }
}
