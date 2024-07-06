

namespace E_Commerce_Backend.Persistence.Configurations;

public class DetailConfiguration :BogusImplementation, IEntityTypeConfiguration<Detail>
{
    public void Configure(EntityTypeBuilder<Detail> builder)
    {
        Detail detail1 = new()
        {
            Id = 1,
            CreatedDate = DateTime.UtcNow,
            IsDeleted = false,
            CategoryId = 1,
            Title = faker.Lorem.Sentence(1),
            Description = faker.Lorem.Sentence(5),

        };
        Detail detail2 = new()
        {
            Id = 2,
            CreatedDate = DateTime.UtcNow,
            IsDeleted = true,
            CategoryId = 3,
            Title = faker.Lorem.Sentence(1),
            Description = faker.Lorem.Sentence(5),

        };
        Detail detail3 = new()
        {
            Id = 3,
            CreatedDate = DateTime.UtcNow,
            IsDeleted = false,
            CategoryId = 4,
            Title = faker.Lorem.Sentence(1),
            Description = faker.Lorem.Sentence(5),

        };
        builder.HasData(detail1, detail2, detail3);
    }
}
