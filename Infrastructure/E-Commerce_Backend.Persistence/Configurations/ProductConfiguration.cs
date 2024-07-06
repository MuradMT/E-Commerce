
namespace E_Commerce_Backend.Persistence.Configurations;

public class ProductConfiguration : BogusImplementation, IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        Product product1 = new()
        {
            Id = 1,
            Title = faker.Commerce.ProductName(),
            Description = faker.Commerce.ProductDescription(),
            Price = faker.Finance.Amount(10, 1000),
            Discount = faker.Random.Decimal(0, 10),
            CreatedDate = DateTime.Now,
            IsDeleted = false,
            BrandId = 1,
        };

          Product product2 = new()
        {
            Id = 2,
            Title = faker.Commerce.ProductName(),
            Description = faker.Commerce.ProductDescription(),
            Price = faker.Finance.Amount(10, 1000),
            Discount = faker.Random.Decimal(0, 10),
            CreatedDate = DateTime.Now,
            IsDeleted = false,
            BrandId = 3,
        };

        builder.HasData(product1, product2);
    }
}
