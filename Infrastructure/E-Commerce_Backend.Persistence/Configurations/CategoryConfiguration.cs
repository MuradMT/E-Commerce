
namespace E_Commerce_Backend.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        Category category1=new(){

            Id=1,
            Name="Electronics",
            ParentId=0,
            Priority=1,
            CreatedDate=DateTime.UtcNow,
            IsDeleted=false
        };

        Category category2=new(){
            Id=2,
            Name="Fashion",
            ParentId=0,
            Priority=2,
            CreatedDate=DateTime.UtcNow,
            IsDeleted=false
        };

        Category parent1=new(){
            Id=3,
            Name="Computer",
            ParentId=1,
            Priority=1,
            CreatedDate=DateTime.UtcNow,
            IsDeleted=false
        };

        Category parent2=new(){
            Id=4,
            Name="Woman",
            ParentId=2,
            Priority=1,
            CreatedDate=DateTime.UtcNow,
            IsDeleted=false
        };

        builder.HasData(category1,category2,parent1,parent2);
    }
}
