
namespace E_Commerce_Backend.Persistence.Configurations;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasKey(x=>new{x.ProductId,x.CategoryId});

        builder.HasOne(p=>p.Product)
        .WithMany(p=>p.ProductCategories)
        .HasForeignKey(p=>p.ProductId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c=>c.Category)
        .WithMany(c=>c.ProductCategories)
        .HasForeignKey(c=>c.CategoryId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
