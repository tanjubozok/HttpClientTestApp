namespace HttpClientTest.Repository.Configurations;

public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.ToTable("AppRoles");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.HasMany(x => x.AppUserRoles)
            .WithOne(x => x.AppRole)
            .HasForeignKey(x => x.AppRoleId);
    }
}
