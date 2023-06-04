namespace HttpClientTest.Repository.Seeds;

public class BlogSeed : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        int counter = 1;
        var faker = new Faker<Blog>("tr")
            .RuleFor(b => b.Id, f => counter++)
            .RuleFor(b => b.Title, f => f.Lorem.Sentence(1, 10))
            .RuleFor(b => b.ShortDescription, f => f.Lorem.Sentence(10, 20))
            .RuleFor(b => b.Description, f => f.Lorem.Paragraph())
            .RuleFor(b => b.ImagePath, "default.jpeg")
            .RuleFor(b => b.AppUserId, f => 1)
            .RuleFor(b => b.CreatedAt, f => f.Date.Past());

        var blogPost = faker.Generate(20);

        builder.HasData(blogPost);
    }
}
