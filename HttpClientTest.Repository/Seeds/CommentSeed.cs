namespace HttpClientTest.Repository.Seeds;

public class CommentSeed : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        int counter = 1;
        var faker = new Faker<Comment>("tr")
            .RuleFor(c => c.Id, f => counter++)
            .RuleFor(c => c.AuthorName, f => f.Name.FullName())
            .RuleFor(c => c.AuthorEmail, f => f.Internet.Email())
            .RuleFor(c => c.Description, f => f.Lorem.Paragraph())
            .RuleFor(c => c.CreatedAt, f => f.Date.Past())
            .RuleFor(c => c.BlogId, f => f.Random.Int(1, 20));

        var comment = faker.Generate(50);

        builder.HasData(comment);
    }
}
