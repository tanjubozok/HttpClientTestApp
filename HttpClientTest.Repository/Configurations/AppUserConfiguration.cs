namespace HttpClientTest.Repository.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable("AppUsers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(x => x.Name)
            .HasMaxLength(64);

        builder.Property(x => x.Surname)
            .HasMaxLength(64);

        builder.HasMany(x => x.Blogs)
            .WithOne(x => x.AppUser)
            .HasForeignKey(x => x.AppUserId);

        builder.HasMany(x => x.AppUserRoles)
            .WithOne(x => x.AppUser)
            .HasForeignKey(x => x.AppUserId);
    }
}
