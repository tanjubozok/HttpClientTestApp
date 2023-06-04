namespace HttpClientTest.Repository.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.AuthorName)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(x => x.AuthorEmail)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.HasMany(x => x.SubComment)
            .WithOne(x => x.ParentComment)
            .HasForeignKey(x => x.ParentCommentId);
    }
}
