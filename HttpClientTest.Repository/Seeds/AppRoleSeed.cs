namespace HttpClientTest.Repository.Seeds;

public class AppRoleSeed : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.HasData(new AppRole[]
        {
            new()
            {
                Id=1,
                Name="Admin"
            },
            new()
            {
                Id=2,
                Name="Member"
            }
        });
    }
}
