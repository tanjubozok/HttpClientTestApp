namespace HttpClientTest.Repository.Seeds;

public class AppUserSeed : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasData(new AppUser[]
        {
            new()
            {
                Id = 1,
                Username = "admin",
                Password = "123456",
                Email = "admin@localhost",
                Name = "Admin",
                Surname = "Guest"
            },
            new()
            {
                Id = 2,
                Username = "member",
                Password = "123456",
                Email = "member@localhost",
                Name = "Member",
                Surname = "Guest"
            }
        });

        int counter = 3;
        // 10 users created with Bogus
        var faker = new Faker<AppUser>("tr")
            .RuleFor(u => u.Id, f => counter++)
            .RuleFor(u => u.Username, f => f.Internet.UserName())
            .RuleFor(u => u.Password, f => f.Internet.Password(6))
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.Name, u.Surname))
            .RuleFor(u => u.Name, f => f.Name.FirstName())
            .RuleFor(u => u.Surname, f => f.Name.LastName());

        List<AppUser> users = faker.Generate(10);

        builder.HasData(users);
    }
}
