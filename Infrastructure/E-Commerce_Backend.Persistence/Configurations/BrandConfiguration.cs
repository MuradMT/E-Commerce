

namespace E_Commerce_Backend.Persistence.Configurations;

/// <summary>
///Extra note- We can add both Domain and Application Layers reference to Infrastructure
/// </summary>

public class BrandConfiguration : BogusImplementation,IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(x=>x.Name).HasMaxLength(256);
        

        Brand brand1=new(){

            Id=1,
            Name=faker.Commerce.Department(),
            CreatedDate=DateTime.Now,
            IsDeleted=false     
        };

        Brand brand2=new(){

            Id=2,
            Name=faker.Commerce.Department(),
            CreatedDate=DateTime.Now,
            IsDeleted=false     
        };
        

        Brand brand3=new(){

            Id=3,
            Name=faker.Commerce.Department(),
            CreatedDate=DateTime.Now,
            IsDeleted=true     
        };

        builder.HasData(brand1,brand2,brand3);
    }
}
