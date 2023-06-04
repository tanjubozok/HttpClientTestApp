namespace HttpClientTest.Repository.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.HasMany(x => x.BlogCategories)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
    }
}
