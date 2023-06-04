namespace HttpClientTest.Repository.Seeds;

public class AppUserRoleSeed : IEntityTypeConfiguration<AppUserRole>
{
    public void Configure(EntityTypeBuilder<AppUserRole> builder)
    {
        builder.HasData(new AppUserRole[] {
            new()
            {
                Id = 1,
                AppRoleId = 1,
                AppUserId = 1,
            },
            new()
            {
                Id = 2,
                AppRoleId = 2,
                AppUserId = 2,
            },
            new()
            {
                Id = 3,
                AppRoleId = 2,
                AppUserId = 3,
            },
            new()
            {
                Id = 4,
                AppRoleId = 2,
                AppUserId = 4,
            },
            new()
            {
                Id = 5,
                AppRoleId = 2,
                AppUserId = 5,
            },
            new()
            {
                Id = 6,
                AppRoleId = 2,
                AppUserId = 6,
            },
            new()
            {
                Id = 7,
                AppRoleId = 2,
                AppUserId = 7,
            },
            new()
            {
                Id = 8,
                AppRoleId = 2,
                AppUserId = 8,
            },
            new()
            {
                Id = 9,
                AppRoleId = 2,
                AppUserId = 9,
            },
            new()
            {
                Id = 10,
                AppRoleId = 2,
                AppUserId = 10,
            },
            new()
            {
                Id = 11,
                AppRoleId = 2,
                AppUserId = 11,
            },
            new()
            {
                Id = 12,
                AppRoleId = 2,
                AppUserId = 12,
            }
        });
    }
}
