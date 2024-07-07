using E_Commerce_Backend.Domain.Common;

namespace E_Commerce_Backend.Domain.Entities;

public class Brand:EntityBase
{
    public Brand()
    {
        
    }
    public Brand(string name)
    {
        Name=name;
    }
     public string? Name { get; set; }
}
