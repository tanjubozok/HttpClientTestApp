namespace HttpClientTest.Repository.Seeds;

public class CategorySeed : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        int counter = 1;
        var faker = new Faker<Category>("tr")
            .RuleFor(c => c.Id, f => counter++)
            .RuleFor(c => c.Name, f => f.Commerce.Department());

        var category = faker.Generate(10);

        builder.HasData(category);
    }
}
