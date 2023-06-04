namespace HttpClientTest.Repository.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.ToTable("Blogs");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(x => x.ShortDescription)
            .IsRequired()
            .HasMaxLength(1024);

        builder.Property(x => x.Description)
            .HasColumnType("ntext");

        builder.HasMany(x => x.BlogCategories)
            .WithOne(x => x.Blog)
            .HasForeignKey(x => x.BlogId);

        builder.HasMany(x => x.Comments)
            .WithOne(x => x.Blog)
            .HasForeignKey(x => x.BlogId);
    }
}
